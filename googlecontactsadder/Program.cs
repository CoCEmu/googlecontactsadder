using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace googlecontactsadder
{
    class Program
    {
        static void Main(string[] args)
        {
            string vcf = "";
            try
            {
                
                Console.WriteLine("input txt file name");
                string filename = Console.ReadLine();
                var file = File.ReadLines(filename);
                var contactnumber = file.ToArray();
                int i = 0;
                int b = 0;
                foreach (string s in contactnumber)
                {
                    i++;
                    vcf += "BEGIN:VCARD" + "\r\n" + "N:" + s + ";;;;" + "\r\n" + "TEL;CELL:" + "98" + s + "\r\n" + "END:VCARD" + "\r\n";
                   // Console.Title = i.ToString() + "from" + contactnumber.Length.ToString();
                    Console.Title= ((i)/ (contactnumber.Length/100)).ToString();
                    if(i==25000)
                    {
                        b++;
                        File.WriteAllText(filename + "-" + contactnumber.Length.ToString()+"-Part"+ b.ToString() + ".vcf", vcf);
                        vcf = "";
                        i = 0;
                    }
                }
                File.WriteAllText(filename + "-" + contactnumber.Length.ToString() + ".vcf", vcf);
            }
            catch
            {

            }
            /*
            BEGIN:VCARD
            N:9357479511;;;;
            TEL;CELL:989357479511
            END:VCARD
             * /
                    /*    try
                        {
                            vCardLib.Collections.vCardCollection vcards = new vCardLib.Collections.vCardCollection();
                            Console.WriteLine("input txt file name");
                            string filename = Console.ReadLine();
                            var file = File.ReadLines(filename);
                            var contactnumber = file.ToArray();
                            int i = 0;
                            foreach (string s in contactnumber)
                            {
                                i++;
                                vCardLib.vCard card = new vCardLib.vCard();
                                card.FamilyName = s;
                                card.PhoneNumbers.Add(new vCardLib.Models.PhoneNumber() { Number = "98" + s, Type = vCardLib.Models.PhoneNumberType.Cell });
                                vcards.Add(card);
                            }
                            Console.WriteLine("Ready to save...");
                            vcards.Save(filename +"-"+vcards.Count.ToString() +".vcf",vCardLib.Helpers.Version.V3);
                            Console.WriteLine("Complate!");
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("error" + "\r\n" + ex.Message.ToString());
                        }*/
        }
    }
}