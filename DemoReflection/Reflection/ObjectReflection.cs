using DemoReflection.CustomedAttributes;
using DemoReflection.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DemoReflection.Reflection
{
    public class ObjectReflection
    {
        public static void Reflect(object obj)
        {
            Type typeObj = obj.GetType();
            Console.WriteLine("Name Obj: " + typeObj.Name);
            //ReadFields(obj);
            //ReadProperties(obj);
            //ReadConstructor(obj);
            //ReadMethod(obj);
            //ExeMethod(obj);
            //ReadCustomedAttribute(obj);
        }

        public static void ReadFields(object obj)
        {
            Console.WriteLine("Fields (public variables don't have get, set methods): ");
            Type typeObj = obj.GetType();
            FieldInfo[] fieldInfos = typeObj.GetFields();
            foreach(var field in fieldInfos)
            {
                Console.WriteLine("\tName: " + field.Name);
                Console.WriteLine("\tType: " + field.FieldType.Name);
                Console.WriteLine("\tValue: " + field.GetValue(obj));
                Console.WriteLine("\t==================================");
            }
        }

        public static void ReadProperties(object obj)
        {
            Console.WriteLine("Properties: ");
            Type typeObj = obj.GetType();
            PropertyInfo[] propertyInfos = typeObj.GetProperties();
            foreach(var prop in propertyInfos)
            {
                Console.WriteLine("\tName: " + prop.Name);
                Console.WriteLine("\tType: " + prop.PropertyType.Name);

                //=====================================================
                //is still true with String (String is class), Array, List property
                if (prop.PropertyType.IsClass && prop.PropertyType.Name != "String")
                {
                    //=====================================================
                    //Array[Object]
                    if (prop.PropertyType.IsArray)
                    {
                        Console.Write("\tValue: ");
                        foreach (var item in (Array)prop.GetValue(obj))
                        {
                            Console.Write(item.ToString() + " ");
                        }
                        Console.WriteLine();
                    }
                    //======================================================
                    //List<Object>
                    else if (prop.PropertyType.IsGenericType)
                    {
                        foreach (var item in (IEnumerable<object>)prop.GetValue(obj))
                        {
                            Type subType = item.GetType();
                            PropertyInfo[] propsItem = subType.GetProperties();
                            foreach (var subProp in propsItem)
                            {
                                Console.WriteLine($"\t\t{subProp.Name}: {subProp.GetValue(item)} - {subProp.PropertyType.Name}");
                            }
                            Console.WriteLine("\t\t-----------------");
                        }
                    }
                    //=====================================================
                    ////Specified Object
                    //else if (prop.PropertyType.IsAssignableFrom(typeof(Subject)))  //specify the instance of Class
                    //    {
                    //    Subject subject = prop.GetValue(obj) as Subject;
                    //    Console.WriteLine("\tValue: ");
                    //    Console.WriteLine("\t\tId: " + subject.Id);
                    //    Console.WriteLine("\t\tName: " + subject.Name);
                    //}
                    else
                    //=====================================================
                    //Object
                    {
                        Console.WriteLine("\tValue: ");
                        Type subType = prop.GetValue(obj).GetType();
                        PropertyInfo[] subPropertyInfos = subType.GetProperties();
                        foreach (var subProp in subPropertyInfos)
                        {
                            Console.WriteLine($"\t\t{subProp.Name}: {subProp.GetValue(prop.GetValue(obj))} - {subProp.PropertyType.Name}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\tValue: " + prop.GetValue(obj));
                }
                Console.WriteLine("\t==================================");
            }
        }

        public static void ReadConstructor(object obj)
        {
            Type type = obj.GetType();
            ConstructorInfo[] constructorInfos = type.GetConstructors();
            Console.WriteLine("Constructors: ");
            foreach(var cons in constructorInfos)
            {
                Console.WriteLine($"\t{cons.GetParameters().Length} params:");
                ParameterInfo[] parameterInfos = cons.GetParameters();
                foreach(var param in parameterInfos)
                {
                    Console.WriteLine($"\t\t{param.Name} - {param.ParameterType.Name}");
                }
                Console.WriteLine("\t-------------------");
            }
        }

        public static void ReadMethod(object obj)
        {
            Type type = obj.GetType();
            MethodInfo[] methodInfos = type.GetMethods();
            Console.WriteLine("Methods: ");
            foreach(var method in methodInfos)
            {
                Console.WriteLine($"\t{method.Name}: ");
                ParameterInfo[] parameterInfos = method.GetParameters();
                foreach (var param in parameterInfos)
                {
                    Console.WriteLine($"\t\t{param.Name} - {param.ParameterType.Name}");
                }
                Console.WriteLine("\t-------------------");
            }
        }

        public static void ExeMethod(object obj)
        {
            Type type = obj.GetType();
            //Non-Parameter
            MethodInfo methodNonParam = type.GetMethod("Rank", new Type[] { });
            string rank = methodNonParam.Invoke(obj, new object[] { }).ToString();
            Console.WriteLine("Rank: " + rank);

            //Parameters
            MethodInfo methodPram = type.GetMethod("Avg", new Type[] { typeof(int) });
            string avg = methodPram.Invoke(obj, new object[] { 5 }).ToString();
            Console.WriteLine("Avg: " + avg);
            
        }

        public static void ReadCustomedAttribute(object obj)
        {
            Type type = obj.GetType();
            //attribute of Class
            object[] attClass = type.GetCustomAttributes(false);
            foreach (var att in attClass)
            {
                if (att is Author)
                {
                    Author author = att as Author;
                    Console.WriteLine($"{att.GetType().Name}: {author.Name} - {author.Country}");
                }
            }
            //attribute of Property
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach(var prop in propertyInfos)
            {
                // false meaning don't use inherrit 
                object[] attProp = prop.GetCustomAttributes(false);
                if (attProp.Length > 0)
                {
                    Console.WriteLine($"\t{prop.Name}");
                    foreach (var att in attProp)
                    {
                        if (att is Required)
                        {
                            Console.WriteLine($"\t\t{att.GetType().Name}");
                        }
                        else if (att is Range)
                        {
                            Range range = att as Range;
                            Console.WriteLine($"\t\t{att.GetType().Name}: {range.MinLength} - {range.MaxLength}");
                        }
                    }
                }
            }
        }

    }
}
