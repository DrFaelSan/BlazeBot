using BlazeBot;

var web = new AutomationWeb();

web.Login("usuário", "senha");

Thread.Sleep(TimeSpan.FromMinutes(5)); //Tempo para usuário passar o captchar.

web.NavegandoParaRoletaBrasileira();


