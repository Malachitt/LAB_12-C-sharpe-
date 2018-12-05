using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleApp12
{
	interface IUser				//Интерфейс
	{
		string Name { get; set; }
		int Age { get; set; }
		void Display();
	}
	class Program
	{
		static void Main(string[] args)
		{
			User user = new User("Tom", 20);		//Конструктор
			Reflect.MethodReflectInfo<User>(user);	//Reflect

			Console.ReadKey();
		}
	}
	
	class Reflect
	{
		public static void MethodReflectInfo<T>(T obj) where T : class
		{
			string writePath = @"E:\sheet\Лабы C#\лаб_12\ath.txt"; 
			Type t = typeof(T);

			MethodInfo[] MArr = t.GetMethods();
			using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
				{
					
				
				Console.WriteLine("*** Список методов класса {0} ***\n", obj.ToString());

				// Вывести методы
				foreach (MethodInfo m in MArr)
				{
					ParameterInfo[] p = m.GetParameters();
						sw.Write(" --> " + m.ReturnType.Name + " \t" + m.Name + "(");
						Console.Write(" --> " + m.ReturnType.Name + " \t" + m.Name + "(");
					// Вывести параметры методов
					for (int i = 0; i < p.Length; i++)
					{
						sw.Write(p[i].ParameterType.Name + " " + p[i].Name);
						Console.Write(p[i].ParameterType.Name + " " + p[i].Name);
						if (i + 1 < p.Length)
						{
							sw.Write(", ");
							Console.Write(", ");
						}

					}
					sw.WriteLine(")\n");
					Console.Write(")\n");
				}
			}

			//интерфейсы
			Type[] MInt = t.GetInterfaces();
			Console.WriteLine("*** Список интерфейсов класса {0} ***\n", obj.ToString());

			//Получаем коллекцию интерфейсов
			foreach(Type m in MInt)
			{
				Console.Write(" --> " + m.MemberType + " \t" + m.Name + "(");
				Console.Write(")\n");
			}

			
			//
			PropertyInfo[] MSvoi = t.GetProperties();
			Console.WriteLine("*** Список свойств класса {0} ***\n", obj.ToString());
			foreach(PropertyInfo m in MSvoi)
			{
				Console.Write(" --> " + m.PropertyType.Name + " \t" + m.Name + "(");
				Console.Write(")\n");
			}

			//
			Console.Write("Введите тип методов и свойств которые надо вывести: ");
			string tip = Console.ReadLine();
			Console.Write("Введите тип параметров методов и свойств которые надо вывести: ");
			string tipP = Console.ReadLine();
			Console.WriteLine("*** Список методов класса {0} ***\n", obj.ToString());

			// Вывести методы
			foreach (MethodInfo m in MArr)
			{
				if(tip.ToString() == m.ReturnType.Name)
				{ 
					//Вывести параметры методов
				   ParameterInfo[] p = m.GetParameters();
					for (int i = 0; i < p.Length; i++)
					{
						if (p[i].ParameterType.Name == tipP.ToString())
						{
							Console.Write(" --> " + m.ReturnType.Name + " \t" + m.Name + "(");
							//Console.Write(p[i].ParameterType.Name + " " + p[i].Name);
							if (i + 1 < p.Length) Console.Write(", ");
						}
					}
					Console.Write(")\n");
				}
			}


		}
	}
	class User : IUser
	{
		public string Name{ get; set; }
		public int Age{ get; set; }
		public User(string name, int age)
		{
			Name = name; Age = age;
		}
		public void Display()
		{
			Console.WriteLine($"Name - {Name}, age - {Age}");
		}
		public void Display1(int age)
		{
			Console.WriteLine(age);
		}
	}
}