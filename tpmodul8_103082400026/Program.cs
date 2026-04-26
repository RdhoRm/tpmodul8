using System;

namespace tpmodul8_103082400026
{
    class Program
    {
        static void Main(string[] args)
        {
            CovidConfig covidConfig = new CovidConfig();

            // Meminta input suhu badan dari pengguna
            Console.WriteLine($"Berapa suhu badan anda saat ini? Dalam nilai {covidConfig.config.satuan_suhu}");
            double suhu = Convert.ToDouble(Console.ReadLine());

            // Meminta input riwayat hari demam
            Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala deman?");
            int hari = Convert.ToInt32(Console.ReadLine());

            bool statusSuhu = false;

            // Pengecekan range suhu sesuai aturan Celcius/Fahrenheit
            if (covidConfig.config.satuan_suhu == "celcius")
            {
                statusSuhu = (suhu >= 36.5 && suhu <= 38.5);
            }
            else if (covidConfig.config.satuan_suhu == "fahrenheit")
            {
                statusSuhu = (suhu >= 97.7 && suhu <= 101.3);
            }

            // Pengecekan batas hari kurang dari config
            bool statusHari = hari < covidConfig.config.batas_hari_deman;

            // Penentuan output ditolak atau diterima
            if (statusSuhu && statusHari)
            {
                Console.WriteLine(covidConfig.config.pesan_diterima);
            }
            else
            {
                Console.WriteLine(covidConfig.config.pesan_ditolak);
            }

            // Memanggil method UbahSatuan
            covidConfig.UbahSatuan();

            Console.ReadLine();
        }
    }
}