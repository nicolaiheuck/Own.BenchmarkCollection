using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BenchmarkDotNet.Attributes;

namespace FirstAttemptOnReflectionTesting
{
    [MemoryDiagnoser]
    public class FirstTesting
    {
        public string Output { get; set; }
        
        [Benchmark]
        public void GetListOfClassNameUsingReflection()
        {
            string classNames = string.Join(",", Assembly.GetExecutingAssembly()
                                                         .GetTypes()
                                                         .Where(t => t.Name.EndsWith("Service") || t.Name.EndsWith("Repository")));
            Output = classNames;
        }
        [Benchmark]
        public void GetListOfClassNameUsingReflectionAndBetterStringManipulation()
        {
            IEnumerable<string> typeNames = Assembly.GetExecutingAssembly()
                                                    .GetTypes()
                                                    .Select(t => t.Name)
                                                    .Where(n => n.EndsWith("Service") || n.EndsWith("Repository"));
            Output = string.Join(",", typeNames);
        }
        [Benchmark]
        public void GetListOfClassNameUsingHardcodedString()
        {
            string classNames = "PersonService,ItemService,OrderService,ProductService,EmailService,SmsService,VerificationService,CompilerService,UserService,CustomerService,StudentService,PersonRepository,ItemRepository,OrderRepository,ProductRepository,EmailRepository,SmsRepository,VerificationRepository,CompilerRepository,UserRepository,CustomerRepository,StudentRepository";
            Output = classNames;
        }
    }
    
    public class PersonService { }
    public class ItemService { }
    public class OrderService { }
    public class ProductService { }
    public class EmailService { }
    public class SmsService { }
    public class VerificationService { }
    public class CompilerService { }
    public class UserService { }
    public class CustomerService { }
    public class StudentService { }
    
    public class PersonRepository { }
    public class ItemRepository { }
    public class OrderRepository { }
    public class ProductRepository { }
    public class EmailRepository { }
    public class SmsRepository { }
    public class VerificationRepository { }
    public class CompilerRepository { }
    public class UserRepository { }
    public class CustomerRepository { }
    public class StudentRepository { }
}