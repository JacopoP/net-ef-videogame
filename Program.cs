namespace net_ef_videogame
{
    internal class Program
    {
        static void Main()
        {
            int controller;
            do
            {
                Console.WriteLine("Cosa vuoi fare?");
                Console.WriteLine("Digita 1 per inserire un nuovo videogioco");
                Console.WriteLine("Digita 2 per cercare un videogioco tramite id");
                Console.WriteLine("Digita 3 per ricercare un videogioco in base al nome");
                Console.WriteLine("Digita 4 per cancellare un videogioco");
                Console.WriteLine("Digita 5 per inserire una nuova software house");
                Console.WriteLine("Digita qualcos'altro per chiudere il programma\n");
                if (!Int32.TryParse(Console.ReadLine(), out controller))
                    controller = 0;
                using VideogameContext db = new VideogameContext();
                switch (controller)
                {
                    case 1:
                        {
                            string? nome;
                            string? descrizione;
                            DateTime dataUscita;
                            long softwareHouse = 0;

                            do
                            {
                                Console.WriteLine("Come si chiama il videogioco?");
                                nome = Console.ReadLine();
                            } while (nome == null);
                            do
                            {
                                Console.WriteLine("Scrivi una breve descrizione del gioco");
                                descrizione = Console.ReadLine();
                            } while (descrizione == null);
                            do
                            {
                                Console.WriteLine("Quando è uscito? (gg/mm/yyyy)");
                            } while (!DateTime.TryParse(Console.ReadLine(), out dataUscita));
                            do
                            {
                                Console.WriteLine("Qual è l'id della software house che l'ha rilascaito?");
                            } while (!long.TryParse(Console.ReadLine(), out softwareHouse));
                            try
                            {
                                Videogame videogame = new Videogame(nome, descrizione, dataUscita);
                                Software_house? s = db.Software_houses.Where(h => h.Id == softwareHouse).FirstOrDefault();
                                if(s != null)
                                {
                                    videogame.Software_house = s;
                                    db.Add(videogame);
                                    db.SaveChanges();
                                    Console.WriteLine(videogame.Name + " salvato con successo!");
                                }
                                else { Console.WriteLine("Software house non trovata"); }
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                        }
                        break;
                    case 2:
                        {
                            int id;
                            do
                            {
                                Console.WriteLine("Qual è l'id del videogioco che vuoi cercare?");
                            } while (!Int32.TryParse(Console.ReadLine(), out id));
                            try
                            {
                                Videogame? videogame = db.Videogames.Where(x => x.Id == id).FirstOrDefault();
                                if (videogame == null)
                                    Console.WriteLine("Nessun risultato");
                                else
                                    Console.WriteLine(videogame.ToString());
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                        }
                        break;
                    case 3:
                        {
                            string? filtro;
                            do
                            {
                                Console.WriteLine("Qual è il nome del videogioco che vuoi cercare?");
                                filtro = Console.ReadLine();
                            } while (filtro == null);
                            try
                            {
                                Videogame? videogame = db.Videogames.Where(x => x.Name.Contains(filtro)).FirstOrDefault();
                                if (videogame == null)
                                    Console.WriteLine("Nessun risultato");
                                else
                                    Console.WriteLine(videogame.ToString());
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                        }
                        break;
                    case 4:
                        {
                            int id;
                            do
                            {
                                Console.WriteLine("Qual è l'id del videogioco che vuoi cancellare?");
                            } while (!Int32.TryParse(Console.ReadLine(), out id));
                            try
                            {
                                Videogame? videogame = db.Videogames.Where(x => x.Id == id).FirstOrDefault();
                                if (videogame == null)
                                    Console.WriteLine("Videogioco non trovato");
                                else
                                {
                                    db.Remove(videogame);
                                    db.SaveChanges();
                                    Console.WriteLine("Cancellato con successo!");
                                }
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                        }
                        break;
                    case 5:
                        {
                            string? nome;
                            string? taxId;
                            string? citta;
                            string? stato;

                            do
                            {
                                Console.WriteLine("Come si chiama la software house?");
                                nome = Console.ReadLine();
                            } while (nome == null);
                            do
                            {
                                Console.WriteLine("Qual è la sua partita iva?");
                                taxId = Console.ReadLine();
                            } while (taxId == null);
                            do
                            {
                                Console.WriteLine("In che città si trova?");
                                citta = Console.ReadLine();
                            } while (citta == null);
                            do
                            {
                                Console.WriteLine("In che Stato si trova?");
                                stato = Console.ReadLine();
                            } while (stato == null);
                            try
                            {
                                Software_house s = new Software_house(nome, taxId, citta, stato);
                                db.Add(s);
                                db.SaveChanges();
                                Console.WriteLine(s.Name + " salvata con successo!");
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                        }
                        break;
                    default:
                        {
                            controller = 0;
                            Console.WriteLine("Grazie per aver usato il servizio!");
                        }
                        break;
                }
                Console.WriteLine();
            } while (controller != 0);
        }
    }
}