using System;
using System.Data;
using System.Globalization;

namespace data
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            TimeSpan();

        }

        static void ExibirData()        //Função criada apenas para organizar os estudos de padrões de formatação
        {
            //Datas
            var dataPadraoInicial = new DateTime();      //tipo primitivo, pega a data padrão (01/01/0001) 
            var data = DateTime.Now;                     //pega a data e hora atual

            //Formatando a String
            var dataFormatada = String.Format("{0:dd/MM/yyyy hh:mm:ss}", data);     //Formatando a data e hora (29/04/2024 01:58:20)

            //Exibindo a Hora
            var horaCurta = String.Format("{0:t}", data);            //exibe a hora compactada (13:57)
            var horaLonga = String.Format("{0:T}", data);            //exibe a hora longa (14:00:10)

            //Exibindo a Data
            var dataCurta = String.Format("{0:d}", data);            //exibe a data compactada (29/04/2024)
            var dataLonga = String.Format("{0:D}", data);            //exibe a data por extenso (segunda-feira, 29 de abril de 2024)

            //Exibindo Data e Hora
            var dataHora = String.Format("{0:f}", data);             //exibe a data e hora por extenso (segunda-feira, 29 de abril de 2024 14:04)
            var dataHoraCurta = String.Format("{0:g}", data);        //exibe a data e hora por extenso (29/04/2024 14:04)
            var formatoPadrao = String.Format("{0:r}", data);        //exibe a data e hora no formato padrão (Mon, 29 Apr 2024 14:06:18 GMT)

            //Padrões
            var sortableDatTime = String.Format("{0:s}", data);      //sortable datetime (2024-04-29T14:09:16)
            var padraoUniversal = String.Format("{0:u}", data);      //padrão universal (2024-04-29 14:09:40Z)


            //Exibe quantos dias tem no mês
            Console.WriteLine(DateTime.DaysInMonth(2024, 2));

            Console.WriteLine(data);
        }

        static void AdicionandoValores()    //Função criada apenas para organizar os estudos de metodo para adicionar valores ás datas
        {
            var data = DateTime.Now;
            Console.WriteLine(data);                //Mostra a Data e Hora 
            Console.WriteLine(data.AddDays(12));    //Adiciona 12 dias na Data
            Console.WriteLine(data.AddMonths(1));   //Adiciona 1 mês á Data
            Console.WriteLine(data.AddYears(1));    //Adiciona 1 ano á Data
        }

        static void CultureInfoTeste()
        {
            var pt = new CultureInfo("pt-PT");      //Seta a cultura escolhida para a data
            var br = new CultureInfo("pt-BR");
            var en = new CultureInfo("en-US");
            var de = new CultureInfo("de-DE");
            var atual = CultureInfo.CurrentCulture;  //Usa a Cultura do sistema

            Console.WriteLine(DateTime.Now.ToString("D", atual));

            //Horário de verão
            Console.WriteLine(DateTime.Now.IsDaylightSavingTime());  //Retorna se é horário de verão no local
        }

        static void Timezone()
        {
            var utcDate = DateTime.UtcNow;  //se tiver Globalização, pega sempre a hora base e não adiciona nenhum Timezone (30/04/2024 14:58:47)
            Console.WriteLine(utcDate.ToLocalTime());

            var timezoneAustralia = TimeZoneInfo.FindSystemTimeZoneById("Pacific/Auckland");   //converte o Timezone para o horario local ((UTC+12:00) Auckland, Wellington)
            Console.WriteLine(timezoneAustralia);

            var horaAustralia = TimeZoneInfo.ConvertTimeFromUtc(utcDate, timezoneAustralia);  //converte a data para o timezone da Australia (01/05/2024 06:04:19)
            Console.WriteLine(horaAustralia);

            var timezones = TimeZoneInfo.GetSystemTimeZones();
            foreach (var timezone in timezones)                         //Listando todos os Timezones
            {
                Console.WriteLine(timezone.Id);
                Console.WriteLine(timezone);
                Console.WriteLine(TimeZoneInfo.ConvertTimeFromUtc(utcDate, timezone));
                Console.WriteLine("__________________");
            }
        }

        static void TimeSpan()
        {
            var timeSpan = new TimeSpan();      //00:00:00
            Console.WriteLine(timeSpan);

            var timeSpanNanoSegundos = new TimeSpan(1);     //00:00:00.0000001
            Console.WriteLine(timeSpanNanoSegundos);

            var timeSpanHoraMinutoSegundo = new TimeSpan(5, 12, 8);     //05:12:08
            Console.WriteLine(timeSpanHoraMinutoSegundo);

            var timeSpanDiaHoraMinutoSegundo = new TimeSpan(3, 5, 50, 10);      //3.05:50:10
            Console.WriteLine(timeSpanDiaHoraMinutoSegundo);

            var timeSpanDiaHoraMinutoSegundoMilissegundos = new TimeSpan(15, 12, 55, 8, 100);       //15.12:55:08.1000000
            Console.WriteLine(timeSpanDiaHoraMinutoSegundoMilissegundos);


            Console.WriteLine(timeSpanHoraMinutoSegundo - timeSpanDiaHoraMinutoSegundo);        //-3.00:38:02
            Console.WriteLine(timeSpanDiaHoraMinutoSegundo.Days);                               //3
            Console.WriteLine(timeSpanDiaHoraMinutoSegundo.Add(new TimeSpan(12, 0, 0)));        //3.17:50:10
        }

        static bool IsWeekend(DayOfWeek today)      //Função retorna true se é fim de semana 
        {
            return today == DayOfWeek.Saturday || today == DayOfWeek.Sunday;
            //Console.WriteLine(IsWeekend(DateTime.Now.DayOfWeek));
        }
    }
}