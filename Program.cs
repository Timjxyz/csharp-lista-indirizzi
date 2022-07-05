StreamReader indirizzi = File.OpenText("C:\\C#.NET-Boolean\\csharp-lista-indirizzi\\addresses.csv");

string intestazione = indirizzi.ReadLine();

List<Indirizzo> indirizziConvertiti = new List<Indirizzo>();
List<string> indirizziCorrotti = new List<string>();   

//Ciclo la lista indirizzi
while(!indirizzi.EndOfStream)
{
    string linea = indirizzi.ReadLine();
    Console.WriteLine(linea);
    string[] data = linea.Split(",");
  
    try
    {
        string name= data[0];
        string surname=data[1];
        string street=data[2];
        string city=data[3];
        string province = data[4];
        string zipString=data[5];
        int zip = int.Parse(zipString);

        
        Indirizzo indirizzo =  new Indirizzo(name,surname,street,city,province,zip);
        indirizziConvertiti.Add(indirizzo);
    }
    catch(Exception e)
    {
        
        indirizziCorrotti.Add(linea);
    }
}

indirizzi.Close();

//Creo il file di testo dove stampare la lista di indirizzi
StreamWriter elencoIndirizzi = File.CreateText("C:\\C#.NET-Boolean\\csharp-lista-indirizzi\\elenco-addresses.txt");

foreach(Indirizzo indirizzo in indirizziConvertiti)
{
    elencoIndirizzi.WriteLine();
    elencoIndirizzi.WriteLine(indirizzo.ToString());
}
elencoIndirizzi.Close();
return;

//Classe indirizzi
public class Indirizzo
{
    public string name { get; set; }
    public string surname { get; set; }
    public string street { get; set; }
    public string city { get; set; }
    public string province { get; set; }
    public int zip { get; set; }

    public Indirizzo(string name, string surname, string street, string city, string province, int zip)
    {
        this.name = name;
        this.surname = surname;
        this.street = street;
        this.city = city;
        this.province = province;
        this.zip = zip;
    }
    public override string ToString()
    {
        
        string stringa ="******Indirizzo******\n";
        stringa += "* Name: "+this.name +"\n";
        stringa += "* Surname: " +this.surname + "\n";
        stringa += "* Street: " +this.street + "\n";
        stringa += "* City: " +this.city + "\n";
        stringa += "* Province: " +this.province + "\n";
        stringa += "* Zip: " +this.zip + "\n";
        stringa += "*********************\n";
        return stringa;
    }



}
//Creo la mia Exception
internal class EmptyFieldException : Exception
{
    public EmptyFieldException() : base()
    {
        // ...
    }
    public EmptyFieldException(string message) : base(message)
    {
        // ...
    }
}
