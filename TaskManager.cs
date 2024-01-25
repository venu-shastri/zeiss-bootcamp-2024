public class Printer{

    public void Print(string path){
        System.Console.WriteLine($"Printing .....{path}");
    }
}

class Scanner{

    public void Scan(string path){
        System.Console.WriteLine($"Scanning .....{path}");
    }
}

public class PrintScanner {

}
public static class TaskManager{
    public static void ExecuctePrintTask(Printer printer,string documentPath){
        printer.Print(documentPath);
    }
    public static void ExecucteScanTask(Scanner scanner,string documentPath){
            scanner.Scan(documentPath);
    }
}

public class Program{
    static void Main(){
        Printer printerObj=new Printer ();
        Scanner scannerObj=new Scanner();
        PrintScanner printScannerObj=new PrintScanner ();

        TaskManager.ExecuctePrintTask(printerObj,"Test.doc");
        TaskManager.ExecucteScanTask(scannerObj,"MyImage.png");
        TaskManager.ExecuctePrintTask(printScannerObj,"NewDoc.doc");
        TaskManager.ExecucteScanTask(printScannerObj,"YourImage.png");
    }
}
