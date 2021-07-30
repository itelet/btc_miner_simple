using System;
using System.Security.Cryptography;
using System.Text;

namespace mininh
{
    
    class Program
    {
        public static class hash1{ // sha256 one way hash
            public static string hashalgorithm(string rawData){
                using (SHA256 sha256Hash = SHA256.Create()){
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++){
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    return builder.ToString();
                }
            }
        }

        public static bool nonce(int block_number, string transactions, string prev_hash, int prefix){
            string resulthash = "";
            for(var nonce = 1; nonce < 1000000; nonce++){
                resulthash = hash1.hashalgorithm((block_number.ToString() + (transactions) + prev_hash + nonce.ToString()));
                if(resulthash.Trim().StartsWith("0000000000")){
                    FoundNonce = resulthash;
                    return true;
                }
            }
            return false;
        }

        public static string FoundNonce = "";
        static void Main(string[] args)
        {
            string text = "find binary code inside image";
            int cycle = 0;
            while(true){
                cycle++;
                Console.WriteLine(cycle);
                if(nonce(682417, text, 
                "000000000000000000003ea9c671f11cc77bb2c91c84c047da438aefbebb9fac", 20) == true){
                    Console.WriteLine("Found it: " + FoundNonce + " At: " + cycle);
                    break;
                }
                else{
                    text = text + 1;
                }
            }

            
        }
    }
}
