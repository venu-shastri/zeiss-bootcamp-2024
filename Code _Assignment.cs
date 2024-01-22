class Device{

[Required(ErrorMessage="ID Property Requires Value")]

  public string Id{ get;set;}
  [Range(10,100,"Code Value Must Be Within 10-100")]
  public int Code{get;set;}
  
  [MaxLength(100,"Max of 100 Charcters are allowed")]
  public string Description{get;set}
  
}

class Program{
    static void Main(){
        Employee emp=new Employee();
        List<string> errors;
        bool isValid=ObjectValidator.Validate(emp,out List<string> errors);
        if(!isValid){
            foreach (string item in errors)
            {
            System.Console.WriteLine(item);
                
            }
        }
    }
}
