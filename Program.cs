using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    static void Main(string[] args)
    {

        bool again= true;
        Console.WriteLine("Benvenuto nel Sistema bancario SIUM S.R.L.");
        Console.WriteLine("Per prima cosa bisogna creare i conti correnti:");
        Console.WriteLine("Quanti utenti vuoi inserire?");

        int numcount = int.Parse(Console.ReadLine());
        
        ContoCorrente[] utenti = new ContoCorrente[numcount];

        for (int i = 0; i < numcount; i++)
        {
            bool isPresent = false;
            Console.Write("Inserisci il tuo nome:");
            string nome = Console.ReadLine();
            Console.Write("Inserisci il tuo cognome:");
            string cognome = Console.ReadLine();
            foreach (ContoCorrente conto in utenti)
            {
                if (conto != null && conto.nome == nome && conto.cognome == cognome)
                {
                    Console.WriteLine("Profilo già esistente");
                    isPresent = true;
                    i--;
                    break;
                }
            }
            if (isPresent == false)
            {
                utenti[i] = new ContoCorrente(nome, cognome);
                utenti[i].apriConto();
                Console.Write("Inserire la cifra del primo versamento");
                int versamento = int.Parse(Console.ReadLine());
                utenti[i].versamento(versamento);
            }
            
        }
        Console.WriteLine("Conti correnti creati correttamente");
        Console.WriteLine("Premere un tasto per continuare");
        Console.ReadLine();
        do
        {
            Console.Clear();
            Console.WriteLine("Quale operazione vuoi eseguire?");
            Console.WriteLine("1) Effettua versamento");
            Console.WriteLine("2) Effettua prelievo");
            Console.WriteLine("3) Stampa tutta la lista dei conti");
            Console.WriteLine("4) Effettua bonifici");
            Console.WriteLine("5) Esci dal programma");
            string comando = Console.ReadLine();
            switch (comando)
            {
                case "1":
                    Console.Write("Inserisci il tuo nome:");
                    string nome = Console.ReadLine();
                    Console.Write("Inserisci il tuo cognome:");
                    string cognome = Console.ReadLine();
                    bool isPresent = false;
                    foreach (ContoCorrente conto in utenti)
                    {
                        if (conto != null && conto.nome == nome && conto.cognome == cognome)
                        {
                            Console.WriteLine($"Quanti soldi vuoi versare?");
                            int vers = int.Parse(Console.ReadLine());
                            conto.versamento(vers);
                            isPresent = true;
                           
                            break;
                        }
                    }
                    if (isPresent == false)
                    {
                        Console.WriteLine("Conto non esistente");
                    }
                    Console.WriteLine("Premere un tasto per continuare");
                    Console.ReadLine();
                    break;
                case "2":
                    Console.Write("Inserisci il tuo nome:");
                    string nome2 = Console.ReadLine();
                    Console.Write("Inserisci il tuo cognome:");
                    string cognome2 = Console.ReadLine();
                    bool isPresent2 = false;
                    foreach (ContoCorrente conto in utenti)
                    {
                        if (conto != null && conto.nome == nome2 && conto.cognome == cognome2)
                        {
                            Console.WriteLine($"Quanti soldi vuoi prelevare?");
                            int prel = int.Parse(Console.ReadLine());
                            conto.prelievo(prel);
                            isPresent2 = true;
                           
                            break;
                        }
                    }
                    if (isPresent2 == false)
                    {
                        Console.WriteLine("Conto non esistente");
                    }
                    Console.WriteLine("Premere un tasto per continuare");
                    break;
                case "3":
                    foreach (ContoCorrente conto in utenti)
                    {
                        conto.details();
                    }
                    Console.WriteLine("Premere un tasto per continuare");
                    Console.ReadLine();
                    break;
                case "4":
                    Console.WriteLine("Quanti bonifici desideri fare?");
                    int nbon = int.Parse(Console.ReadLine());
                    int somma = 0;
                    int[] bonifici = new int[nbon];
                    for(int i = 0; i < nbon; i++)
                    {
                       Console.WriteLine("Inserisci la cifra del bonifico da effettuare");
                       bonifici[i]=int.Parse(Console.ReadLine());
                    }
                    foreach (int i in bonifici)
                    {
                        somma += i;
                    }
                    Console.WriteLine($"La somma di tutti i bonifici è{somma}");
                    Console.WriteLine($"La media di tutti i bonifici è{somma/bonifici.Length}");
                    Console.WriteLine("Premere un tasto per continuare");
                    Console.ReadKey();
                    break;
                case "5":
                    again = false;
                    break;
            }
        }
        while (again);
        
        
    }


    class ContoCorrente
    {
        public string nome;
        public string cognome;
        private int saldo;
        private int nconto;
        private bool isOpen=false;
        Random random = new Random();


        public ContoCorrente(string _nome,string _cognome)
        {
            nome = _nome;
            cognome = _cognome;
        }
 
        public void apriConto()
        {
            
            if (isOpen == true)
            {
                Console.WriteLine("Conto già esistente");
                
            }
            else
            {
                nconto = random.Next(100000);
                Console.WriteLine($"Conto numero {nconto} aperto, primo versamento obbligatorio....");
                isOpen = true;
            }
        }
        public void versamento(int vers)
        {
            if (isOpen==true)
            {
                saldo += vers;
                Console.WriteLine($"Il tuo nuovo saldo è:{saldo}");
                
            }
            else
            {
                Console.WriteLine("Conto non esistente");
                
            }
            
        }
        public void prelievo(int prel)
        {
            if (isOpen==true)
            {
                if (saldo >= prel)
                {
                    saldo -= prel;
                    Console.WriteLine($"Il tuo nuovo saldo è:{saldo}");
                    

                }
                else
                {
                    Console.WriteLine("Saldo non sufficente");
                    
                }
            }
 
        }
        public void details()
        {
            Console.WriteLine($"Nome:{nome}   Cognome:{cognome}  NumConto:{nconto}   Saldo:{saldo}");
        }
    }
}