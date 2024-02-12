﻿using System;
using Internal;

namespace Botiga_I_Cistella_OscarReusMartinez_MarcVancea
{
    internal class Program
    {
        static string[] productesCistella;
        static int[] quantitat;
        static int nElemCistella;
        static double diners;

        static void Main(string[] args)
        {
            productesCistella = new string[10];
            quantitat = new int[10];
            nElemCistella = 0;
            diners = 100.0m;

            OrdenarCistella();

            Console.WriteLine(Mostra());
        }
        static bool ComprarProducte(string producte, int quantitat, double preu)
        {
            // Comprova si el producte existeix a la botiga
            if (!ExisteixProducte(producte))
            {
                Console.WriteLine("El producte no existeix a la botiga.");
                return false;
            }

            // Obté el preu del producte
            decimal preu = ObtenirPreu(producte);

            // Comprova si hi ha suficient espai a la cistella
            if (nElemCistella + quantitat > productesCistella.Length)
            {
                Console.WriteLine("No hi ha suficient espai a la cistella. Considera ampliar la cistella.");
                return false;
            }

            // Comprova si tens suficients diners
            if (diners < preu * quantitat)
            {
                Console.WriteLine("No tens suficients diners per a aquesta compra. Considera ingressar més diners.");
                return false;
            }

            // Afegeix el producte a la cistella
            for (int i = 0; i < quantitat; i++)
            {
                productesCistella[nElemCistella] = producte;
                nElemCistella++;
            }

            // Descompta els diners
            diners -= preu * quantitat;

            return true;
        }
        static bool ExisteixProducte(string producte)
        {
            for (int i = 0; i < productesBotiga.Length; i++)
            {
                if (productesBotiga[i] == producte)
                {
                    return true;
                }
            }
            return false;
        }
        static decimal ObtenirPreu(string producte)
        {
            for (int i = 0; i < productesBotiga.Length; i++)
            {
                if (productesBotiga[i] == producte)
                {
                    return preusBotiga[i];
                }
            }
            return -1;
        }




        static string Mostra()
        {
            string tiquet = "";
            for (int i = 0; i < nElemCistella; i++)
            {
                tiquet += "Producte: " + productesCistella[i] + ", Quantitat: " + quantitat[i] + "\n";
            }
            tiquet += "Total a pagar: " + diners;
            return tiquet;
        }
    }
}