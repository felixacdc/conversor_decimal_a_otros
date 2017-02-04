//Rextester.Program.Main is the entry point for your code. Don't change it.
//Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
 
namespace Rextester 
{
    public class Program 
    {
        static Dictionary<char, int> hexdecval = new Dictionary<char, int>{
            {'0', 0},
            {'1', 1},
            {'2', 2},
            {'3', 3},
            {'4', 4},
            {'5', 5},
            {'6', 6},
            {'7', 7},
            {'8', 8},
            {'9', 9},
            {'a', 10},
            {'b', 11},
            {'c', 12},
            {'d', 13},
            {'e', 14},
            {'f', 15},
        };

        public static void Main(string[] args) 
        {
            int opcion = 0;
            
            while(opcion != 7) {
              Console.Write("1.- Decimal a Hexadecimal\n");
              Console.Write("2.- Decimal a Octal\n");
              Console.Write("3.- Decimal a Binario\n");
              Console.Write("4.- Hexadecimal a Decimal\n");
              Console.Write("5.- Octal a Decimal\n");
              Console.Write("6.- Binario a Decimal\n");
              Console.Write("7.- Salir\n");
              Console.Write("Ingrese su opcion: ");
              
              opcion = int.Parse(Console.ReadLine());
              Console.Clear();
              
              switch(opcion) {
                case 1:
                  DecimalAHexa();
                  break;
                case 2:
                  DecimalAOctal();
                  break;
                case 3:
                    DecimalABinario();
                  break;
                case 4:
                  HexadecimalADecimal();
                  break;
                case 5:
                  OctalADecimal();
                  break;
                case 6:
                  BinarioADecimal();
                  break;
                case 7:
                  break;
              }
              
              Console.Clear();
            }
        }
        
        public static void DecimalAHexa(){
          int number = 0;
          String hexadecimal = "";
          
          Console.Write("====Decimal a Hexadecimal=====\n");
          Console.Write("Escriba un numero decimal positivo: ");
          number = int.Parse(Console.ReadLine());
          
          if(number >= 0) {
            while(true) { 
              if((number % 16) != 0) {
                if((number % 16) > 9) {
                  switch(number % 16) { 
                    case 10:
                      hexadecimal = "A" + hexadecimal;
                      break;
                    case 11:
                      hexadecimal = "B" + hexadecimal;
                      break;
                    case 12:
                      hexadecimal = "C" + hexadecimal;
                      break;
                    case 13:
                      hexadecimal = "D" + hexadecimal;
                      break;
                    case 14:
                      hexadecimal = "E" + hexadecimal;
                      break;
                    case 15:
                      hexadecimal = "F" + hexadecimal;
                      break;
                  }
                } else
                  hexadecimal = (number % 16).ToString() + hexadecimal;
                
              } else
                hexadecimal = "0" + hexadecimal;
              
              number /= 16;
              if(number <= 0)
                break;
            }
          } else {
            hexadecimal = "Ingrese un numero positivo";
          }
          
          Console.WriteLine("El numero hexadecimal es: " + hexadecimal);
          Console.ReadKey();
        }
        
        public static void DecimalAOctal(){
          int numero = 0;
          String octal = "";
          
          Console.Write("====Decimal a Octal=====\n");
          Console.Write("Ingrese un numero decimal positivo: ");
          numero = int.Parse(Console.ReadLine());
          
          if(numero >= 0) {
            while(true)
            {
              if((numero % 8) != 0)
                octal = (numero % 8).ToString() + octal;
              else
                octal = "0" + octal;
              
              numero /= 8;
              if(numero <= 0)
                break;
            }
          } else {
            octal = "Ingrese un numero positivo";
          }
          
          Console.WriteLine("El resultado de la conversion es: " + octal);
          Console.ReadKey();
        }
        
        public static void DecimalABinario() {
          int numero = 0;
          String binario = "";
          
          Console.Write("====Decimal a Binario=====\n");
          Console.Write("Ingrese un numero decimal positivo: ");
          numero = int.Parse(Console.ReadLine());
          
          if (numero > 0) {
            
              while (numero > 0) {
                  if (numero%2 == 0) {
                      binario = "0" + binario;
                  } else {
                      binario = "1" + binario;
                  }
                  numero = (int) numero/2;
              }
              
          } else if (numero == 0) {
              binario = "0";
          } else {
              binario = "No se pudo convertir el Numero. Ingrese solo numeros positivos";
          }
          
          Console.WriteLine("El resultado de la conversion es: " + binario);
          Console.ReadKey();
        }

        public static void HexadecimalADecimal() {
          string hex = "";
          int result = 0;
          
          Console.Write("Escribe un numero hexadecimal: ");
          hex = Console.ReadLine();
          
          hex = hex.ToLower();
  
          for (int i = 0; i < hex.Length; i++)
          {
              char valAt = hex[hex.Length - 1 - i];
              result += hexdecval[valAt] * (int)Math.Pow(16, i);
          }
          
          Console.Write("El numero decimal es: {0}",result);
            
          Console.ReadKey();
        }

        public static void OctalADecimal() {
          int numero = 0;
          string oc = "";
          bool v = true;
          
          Console.Write("Escribe un numero octal: ");
          oc = Console.ReadLine();
          
          for (int x = oc.Length - 1, y = 0; x >= 0; x--, y++) {
            if((int.Parse(oc[x].ToString()) >= 0) && (int.Parse(oc[x].ToString()) <= 7)) {
              numero += (int)(int.Parse(oc[x].ToString()) * Math.Pow(8,y));
            } else {
              Console.Write("El numero no es octal");
              v = false;
              break;
            }
          }
          
          if(v)
            Console.Write("El numero decimal es: {0}",numero);
            
          Console.ReadKey();
        }

        public static void BinarioADecimal() {
          int numero = 0;
          string bin = "";
          bool v = true;
          
          Console.Write("Escribe un numero binario: ");
          bin = Console.ReadLine();
          
          for (int x = bin.Length - 1, y = 0; x >= 0; x--, y++) {
            if(bin[x] == '0' || bin[x] == '1') {
              numero += (int)(int.Parse(bin[x].ToString()) * Math.Pow(2,y));
            } else {
              Console.Write("El numero no es binario");
              v = false;
              break;
            }
          }
          
          if(v)
            Console.Write("El numero decimal es: {0}",numero);
            
          Console.ReadKey();
        }
    }
}