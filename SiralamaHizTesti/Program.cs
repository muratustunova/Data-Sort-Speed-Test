using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Text.RegularExpressions;
/*  System.Text.RegularExpressions Ad alanı, .NET Framework normal ifade motoru erişimi sağlayan sınıflar içerir.
    Ad alanı, herhangi bir platform veya Microsoft .NET Framework içinde çalışan dil kullanılabilir
    normal ifade işlevsellik sağlar. Bu ad alanında yer alan tür yanı sıra RegexStringValidator sınıfı
    belirli bir dizenin bir normal ifade deseni için uygun olup olmadığını belirlemenize olanak sağlar.*/
using System.Diagnostics; 
/*  System.Diagnostics Ad alanı, sistem işlemleri, olay günlükleri ve performans sayaçları
 *  ile etkileşimde bulunmanızı 
    sağlayan sınıfları sağlar.*/
namespace SiralamaHizTesti
{
    class Program
    {
        static void Main(string[] args)
        {
 /*        Yaptığı İşlemler:
            1-)Oluşturulan dizinin boyutunu girmenizi ister.
            2-)Girdiğiniz boyutun genişiliği kadar rastgele sayı üretir.
            3-)6 farklı sıralama içerisinden birini seçmenizi ister.
            4-)Sıralama işlemini doğru bir şekilde yapar ve işlem boyunca geçen süreyi ekrana basar.                                                   */
            #region Rastgele Sayı Üretme Bölümü
            Console.WriteLine("\t\t\tİŞLEM-HIZ TESTİ UYGULAMASI\n\nDizinin Boyutu Girin: ");
            int uzunluk,uzunluk2;
            uzunluk = Convert.ToInt32(Console.ReadLine()); Console.WriteLine("\n");
            uzunluk2 = uzunluk;
            int hello = uzunluk;
            hello = uzunluk / 2;
            int[] dizi = new int[uzunluk];
            //random sayı üretme kısmı
            Random random = new Random();
            for(int i=0; i<uzunluk;i++)
            {
                dizi[i]= random.Next(0, 9000000);    
            }
            //Timer tanımlama kısmı 
            Stopwatch time = new Stopwatch(); 
            Console.WriteLine("1-)Quick Sort\n2-)Bubble Sort\n3-)Selection Sort\n4-)Merge Sort\n" +
                "5-)Insertion Sorting\n6-)Tree Sort\n0-)Programı Sonlandır.\n");
            Console.WriteLine("Sıralama Metodunu Girin: ");
            int denemesayisi = 0;
            #endregion
            #region İşlem Seçim Bölümü
            while (denemesayisi < 24)
            {
                int[] GeciciDizi = new int[uzunluk];
                dizi.CopyTo(GeciciDizi, 0); int choose;
                choose = Convert.ToInt32(Console.ReadLine());
                denemesayisi+=1;
                switch (choose)
                {
                    case 1: {
                            Console.Write("Quick Sort: ");
                            time.Start(); 
                            QuickSort(GeciciDizi, 0, dizi.Count() - 1); //(kaynak, hedef, kopyalanacak eleman sayısı);
                            time.Stop(); 
                            ZamanYazdir(time.Elapsed.Minutes,time.Elapsed.Seconds, time.Elapsed.Milliseconds);
                            Console.WriteLine("En büyük değer: " + GeciciDizi.Last());
                            Console.WriteLine(GeciciDizi[hello]);
                            Yazdir(GeciciDizi); 
                            Console.WriteLine("\n"); break;
                        }
                    case 2: {
                            Console.WriteLine("Bubble Sort: ");
                            time.Start();
                            BubbleSort(GeciciDizi);
                            time.Stop();
                            ZamanYazdir(time.Elapsed.Minutes, time.Elapsed.Seconds, time.Elapsed.Milliseconds);
                            Console.WriteLine("En büyük değer: " + GeciciDizi.Max());
                            Yazdir(GeciciDizi);
                            Console.WriteLine("\n"); break;
                        }
                    case 3: {
                            Console.Write("Selection Sort: ");
                            time.Start();
                            SelectionSort(GeciciDizi);
                            time.Stop();
                            ZamanYazdir(time.Elapsed.Minutes, time.Elapsed.Seconds, time.Elapsed.Milliseconds);
                            Console.WriteLine("En büyük değer: " + GeciciDizi.Max());
                            Yazdir(GeciciDizi);
                            Console.WriteLine("\n"); break;
                        }
                    case 4: {
                            Console.Write("Merge Sort: ");
                            time.Start();
                            MergeSort(GeciciDizi, 0, dizi.Count() - 1);
                            time.Stop();
                            ZamanYazdir(time.Elapsed.Minutes, time.Elapsed.Seconds, time.Elapsed.Milliseconds);
                            Console.WriteLine("En büyük değer: " + GeciciDizi.Max());
                            Yazdir(GeciciDizi);
                            Console.WriteLine("\n"); break;
                        }
                    case 5:
                        {
                            Console.Write("Insertion Sorting: ");
                            time.Start();
                            InsertionSort(GeciciDizi);
                            time.Stop();
                            ZamanYazdir(time.Elapsed.Minutes, time.Elapsed.Seconds, time.Elapsed.Milliseconds);
                            Console.WriteLine("En büyük değer: " + GeciciDizi.Max());
                            time.Reset();
                            Yazdir(GeciciDizi);
                            Console.WriteLine("\n"); break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Tree Sort: ");
                            Tree(GeciciDizi);
                            ZamanYazdir(time.Elapsed.Minutes, time.Elapsed.Seconds, time.Elapsed.Milliseconds);
                            Console.WriteLine("En büyük değer: " + GeciciDizi.Max());
                            Yazdir(GeciciDizi);
                            Console.WriteLine("\n");break;
                        }
                    case 0:
                        {
                            Console.WriteLine("Program sonlandı...");
                            System.Environment.Exit(0); break;
                        }
                    default:
                        {
                            Console.WriteLine("\nYanlış Seçim yapıldı\n");
                            break;
                        }
                }
            }
            #endregion
        }
        #region Matematiksel İşlemler
        public static void QuickSort(int[] dizi, int baslangic, int bitis)
        {
            int i;
            if (baslangic < bitis)
            {
                i = Parca(dizi, baslangic, bitis);
                QuickSort(dizi, baslangic, i - 1);
                QuickSort(dizi, i + 1, bitis);
            }
        }
        public static void BubbleSort(int[] dizi)
        {
            int gecici;

            for (int i = 0; i <= dizi.Length - 1; i++)
            {
                for (int j = 1; j <= dizi.Length - 1; j++)
                {
                    if (dizi[j - 1] > dizi[j])
                    {
                        gecici = dizi[j - 1];
                        dizi[j - 1] = dizi[j];
                        dizi[j] = gecici;
                    }
                }
            }
        }
        public static void SelectionSort(int[] dizi)
        {
            int n = dizi.Length;
            int yedek;
            int minindex;

            for (int i = 0; i < n - 1; ++i)
            {
                minindex = i;

                for (int j = i; j < n; j++)
                {
                    if (dizi[j] < dizi[minindex])
                        minindex = j;
                }
                yedek = dizi[i];
                dizi[i] = dizi[minindex];
                dizi[minindex] = yedek;
            }
        }
        public static void MergeSort(int[] dizi, int basla, int bitis)
        {
            if (basla < bitis)
            {
                int orta = (basla + bitis) / 2;
                MergeSort(dizi, basla, orta);
                MergeSort(dizi, orta + 1, bitis);
                MergeSortArray(dizi, basla, orta, bitis);
            }
        }
        public static void MergeSortArray(int[] dizi, int basla, int orta, int bitis)
        {
            int[] gecici = new int[bitis - basla + 1];
            int i = basla, j = orta + 1, k = 0;

            while (i <= orta && j <= bitis)
            {
                if (dizi[i] < dizi[j])
                {
                    gecici[k] = dizi[i];
                    k++;
                    i++;
                }
                else
                {
                    gecici[k] = dizi[j];
                    k++;
                    j++;
                }
            }//ilk while sonu
            while (i <= orta)
            {
                gecici[k] = dizi[i];
                k++;
                i++;
            }//ikinci while sonu
            while (j <= bitis)
            {
                gecici[k] = dizi[j];
                k++;
                j++;
            }//üçüncü while sonu
            k = 0;
            i = basla;
            while (k < gecici.Length && i <= bitis)
            {
                dizi[i] = gecici[k];
                k++;
                i++;
            }//dördüncü while sonu
        }
        static int[] InsertionSort(int[] dizi)
        {
            for (int i = 0; i < dizi.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (dizi[j - 1] > dizi[j])
                    {
                        int temp = dizi[j - 1];
                        dizi[j - 1] = dizi[j];
                        dizi[j] = temp;
                    }
                }
            }
            return dizi;
        }
        public static void Tree(int[] dizi)
        {
            Stopwatch time = new Stopwatch();

            List<int> Trees = new List<int>();
            for (int i = 0; i < dizi.Length; i++)
            {
                Trees.Add(dizi[i]);
            }
            time.Start();
            Trees.Sort();
            time.Stop();
        }
        public static int Parca(int[] A, int baslangic, int bitis)
        {
            int gecici;
            int x = A[bitis];
            int i = baslangic - 1;
            for (int j = baslangic; j <= bitis; j++)
            {
                if (A[j] < x)
                {
                    i++;
                    gecici = A[i];
                    A[i] = A[j];
                    A[j] = gecici;
                }
            }
            gecici = A[i + 1];
            A[i + 1] = A[bitis];
            A[bitis] = gecici;
            return i + 1;

        }
        #endregion
        #region Yazdırma Ve Zaman Düzenleme İşlemleri
        public static void Yazdir(int[] dizi)
        {
            /*    for (int i = 0; i < dizi.Length; i++)
                     {
                         Console.Write(dizi[i] + " ");
                     }
              */
            Console.WriteLine("Sıralama Tamamlandı..");
        }
        
        //Zamanın yazdırılması
        public static void ZamanYazdir(int minutes, int seconds, int milliseconds)
        {

            while (milliseconds > 100)
            {   //milisaniyeyi yüzlü değerde yazdırdığı için 100 ve üzeri ise döngüye girip modunu alıp tekrar kontrolü sağlanıyor ve saniye 1 arttırılıyor.
                milliseconds = milliseconds % 100;
                seconds++;
            }
            if (minutes > 1)
            {
                Console.WriteLine("\nSıralama süresi: {0}.{1}.{2} Dakika", minutes, seconds, milliseconds);
            }
            else if (seconds > 1 && seconds < 60)
            {
                Console.WriteLine("\nSıralama süresi: {0}.{1} Saniye", seconds, milliseconds);
            }
            else
                Console.WriteLine("\nSıralama süresi: {0} Milisaniye", milliseconds);
            
            //sayaç sıfırlama
            minutes = 0;
            seconds = 0;
            milliseconds = 0;
        }
        #endregion
    }
}
