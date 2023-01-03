using Microsoft.AspNetCore.SignalR;

namespace SignalR_API.Hubs
{
    public class MyHub:Hub
    {
        //Clientların çağıracağı metodları tanımlıyoruz asenkron olarak 

        public static List<string> Names { get; set; } = new List<string>(); //static olarak tanımlamamızın sebebi MyHub classını her çağırıldığında bir nesne oluşturulması 
        //uygulamamız çalıştığı sürece Names verilerine erişebileceğiz static yaptığımız için gerçek hayatta proje yaparsak veritabanına kayıt edebiliriz şimdi memoryde geçici tutacağız.
        public async Task SendName(string name)
        {
            Names.Add(name);
            //Clientlardaki metodların çalışması için bir istek göndereceğiz 
            await Clients.All.SendAsync("ReceiveName", name); //bağlı olan tüm clientlara istek gönderir "ReceiveMessage" Clientlardaki metodun adıdır. yanına da data gönderebiliriz message gibi
            
        }

        //Clientda o anda memoryde olan tüm stringleri alan metod
        public async Task GetNames()
        {
            await Clients.All.SendAsync("ReceiveNames", Names);
        }
    }
}
