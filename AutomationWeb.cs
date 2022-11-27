using BlazeBot.Dto;
using BlazeBot.Util;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;

namespace BlazeBot;

public class AutomationWeb
{
    public IWebDriver driver;

    public AutomationWeb()
        => driver = new ChromeDriver();


    public void Login(string _userName, string _password)
    {
        driver.Navigate().GoToUrl(@"https://blaze.com/pt?modal=auth&tab=login");

        driver.Manage().Window.Maximize();

        driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);

        //userName
        driver.FindElement(By.XPath(@"/html/body/div[1]/main/div[3]/div/div[2]/div/form/div[1]/div/input")).Click();
        driver.FindElement(By.XPath(@"/html/body/div[1]/main/div[3]/div/div[2]/div/form/div[1]/div/input")).SendKeys(_userName);
        Thread.Sleep(TimeSpan.FromSeconds(1));

        //password
        driver.FindElement(By.XPath(@"/html/body/div[1]/main/div[3]/div/div[2]/div/form/div[2]/div/input")).Click();
        driver.FindElement(By.XPath(@"/html/body/div[1]/main/div[3]/div/div[2]/div/form/div[2]/div/input")).SendKeys(_password);
        Thread.Sleep(TimeSpan.FromSeconds(1));

        // Button Login
        driver.FindElement(By.XPath(@"/html/body/div[1]/main/div[3]/div/div[2]/div/form/div[4]/button")).Click();
        

    }

    public void NavegandoParaRoletaBrasileira() 
    {
        driver.Navigate().GoToUrl(@"https://blaze.com/pt/games/roleta-brasileira");
        driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);

        //Aumentar a tela do jogo
        driver.FindElement(By.XPath(@"/html/body/div[1]/main/div[1]/div[4]/div/div[1]/div/div[1]/div[2]/div[2]/div[2]/svg[2]")).Click();


        var elementoDeContagemDeTempo = SeleniumExtensions.WaitUntilElementExists(driver, By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[5]/div[1]/div"), 35);
        //Aqui eu tenho 15 segundos
        JogandoNumerosQuentesEFrios();



        //driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[5]/div[1]/div")); //enquanto existir esse cara podemos fazer a aposta :) 

        //driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[12]/div")); //modal do resultado :)



    }

    public void Jogar() 
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        JogandoNumerosQuentesEFrios();

        JogandoEmEstatisticas();
        
        
        stopwatch.Stop();
        Console.WriteLine($"Tempo passado: {stopwatch.Elapsed.TotalMilliseconds} ms");
        
    }

    public void JogandoNumerosQuentesEFrios() {

        //Abrir Grafico quentes e frios
        driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[1]/div[1]/ul/li[6]")).Click();
        Thread.Sleep(TimeSpan.FromMilliseconds(150));

        for (int i = 1; i < 5; i++)
        {
            if (i == 1)
                //100 ultimos
                driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[11]/div/div[2]/div/div/div[2]/div/div/div[1]/div[1]")).Click();
            else if (i == 2)
                //200 ultimos
                driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[11]/div/div[2]/div/div/div[2]/div/div/div[1]/div[2]")).Click();
            else if (i == 3)
                //500 ultimos
                driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[11]/div/div[2]/div/div/div[2]/div/div/div[1]/div[3]")).Click();
            else
                //1000 ultimos
                driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[11]/div/div[2]/div/div/div[2]/div/div/div[1]/div[4]")).Click();

            //Apostar em Numeros quentes
            driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[11]/div/div[2]/div/div/div[1]/div[1]")).Click();
            Thread.Sleep(TimeSpan.FromMilliseconds(100));

            //Apostar em Numeros Frios
            driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[11]/div/div[2]/div/div/div[1]/div[3]")).Click();
            Thread.Sleep(TimeSpan.FromMilliseconds(100));

        }
        //Fechar Grafico quentes e frios
        driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[1]/div[1]/ul/li[6]")).Click();
        Thread.Sleep(TimeSpan.FromMilliseconds(150));
    }

    public void JogandoEmEstatisticas() {
        //Abrir Estatisticas
        driver.FindElement(By.XPath("/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[1]/div[1]/ul/li[4]")).Click();
        Thread.Sleep(TimeSpan.FromMilliseconds(150));
        EstatisticasDto estatisticas = new();
        for (int i = 1; i < 5; i++)
        {
            if (i == 1)
                //100 ultimos
                driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[11]/div/div[2]/div/div/div[2]/div/div/div[2]/div")).Click();
            else if (i == 2)
                //200 ultimos
                driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[11]/div/div[2]/div/div/div[2]/div/div/div[1]/div[2]")).Click();
            else if (i == 3)
                //500 ultimos
                driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[11]/div/div[2]/div/div/div[2]/div/div/div[1]/div[3]")).Click();
            else
                //1000 ultimos
                driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[11]/div/div[2]/div/div/div[2]/div/div/div[1]/div[4]")).Click();

            CapturandoPorcentagens(estatisticas);
            Thread.Sleep(TimeSpan.FromMilliseconds(50));
        }

        estatisticas.MediaPonderada();

        //Todo: Percorrer resultados e executalos na Roleta.



    }

    public void CapturandoPorcentagens(EstatisticasDto _estatisticas) {

        var preto = ConvertPorcentagemToDouble(driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[11]/div/div[2]/div/div/div[1]/div/div[1]/div[1]/div[1]/span")).Text);
        var vermelho = ConvertPorcentagemToDouble(driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[11]/div[1]/div[2]/div/div/div[1]/div/div[1]/div[3]/div[1]/span")).Text);
        var verdeZero = ConvertPorcentagemToDouble(driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[11]/div/div[2]/div/div/div[1]/div/div[1]/div[2]/div[1]/span")).Text);


        var baixo = ConvertPorcentagemToDouble(driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[11]/div/div[2]/div/div/div[1]/div/div[2]/div[3]/div[1]/span")).Text);
        var alto = ConvertPorcentagemToDouble(driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[11]/div/div[2]/div/div/div[1]/div/div[2]/div[4]/div[1]/span")).Text);

        var par = ConvertPorcentagemToDouble(driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[11]/div/div[2]/div/div/div[1]/div/div[2]/div[1]/div[1]/span")).Text);
        var impa = ConvertPorcentagemToDouble(driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[11]/div/div[2]/div/div/div[1]/div/div[2]/div[2]/div[1]/span")).Text);


        double primeiraCol, segundaCol, terceiraCol, primeiraDuz, segundaDuz, terceiraDuz;
        //Caluna
        try
        {
             primeiraCol = ConvertPorcentagemToDouble(driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[11]/div/div[2]/div/div/div[1]/div/div[3]/div[4]/div[1]/span")).Text);
            segundaCol = ConvertPorcentagemToDouble(driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[11]/div/div[2]/div/div/div[1]/div/div[3]/div[5]/div[1]/span")).Text);
            terceiraCol = ConvertPorcentagemToDouble(driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[11]/div/div[2]/div/div/div[1]/div/div[3]/div[6]/div[1]/span")).Text);
        }
        catch
        {
            primeiraCol = ConvertPorcentagemToDouble(driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[12]/div/div[2]/div/div/div[1]/div/div[3]/div[4]/div[1]/span")).Text);
            segundaCol = ConvertPorcentagemToDouble(driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[12]/div/div[2]/div/div/div[1]/div/div[3]/div[5]/div[1]/span")).Text);
            terceiraCol = ConvertPorcentagemToDouble(driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[12]/div/div[2]/div/div/div[1]/div/div[3]/div[6]/div[1]/span")).Text);
        }

        //Duzias
        try
        {
             primeiraDuz = ConvertPorcentagemToDouble(driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[11]/div/div[2]/div/div/div[1]/div/div[3]/div[1]/div[1]/span ")).Text);
            segundaDuz = ConvertPorcentagemToDouble(driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[11]/div/div[2]/div/div/div[1]/div/div[3]/div[2]/div[1]/span")).Text);
            terceiraDuz = ConvertPorcentagemToDouble(driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[11]/div/div[2]/div/div/div[1]/div/div[3]/div[3]/div[1]/span")).Text);
        }
        catch 
        {
             primeiraDuz = ConvertPorcentagemToDouble(driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[12]/div/div[2]/div/div/div[1]/div/div[3]/div[1]/div[1]/span ")).Text);
            segundaDuz = ConvertPorcentagemToDouble(driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[12]/div/div[2]/div/div/div[1]/div/div[3]/div[2]/div[1]/span")).Text);
            terceiraDuz = ConvertPorcentagemToDouble(driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[12]/div/div[2]/div/div/div[1]/div/div[3]/div[3]/div[1]/span")).Text);
        }


        var tier = ConvertPorcentagemToDouble(driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[11]/div/div[2]/div/div/div[1]/div/div[4]/div[1]/div[1]/span")).Text);
        var orfans = ConvertPorcentagemToDouble(driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[11]/div/div[2]/div/div/div[1]/div/div[4]/div[2]/div[1]/span")).Text);
        var vorsis = ConvertPorcentagemToDouble(driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[11]/div/div[2]/div/div/div[1]/div/div[4]/div[3]/div[1]/span")).Text);
        var zero = ConvertPorcentagemToDouble(driver.FindElement(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div/div[1]/div/div/div[2]/div[11]/div/div[2]/div/div/div[1]/div/div[4]/div[4]/div[1]/span")).Text);

        _estatisticas.Abastecer(preto, vermelho, verdeZero, baixo, alto, par, impa, primeiraCol, segundaCol, terceiraCol, primeiraDuz, segundaDuz, terceiraDuz, tier, orfans, vorsis, zero);

    }


    public double ConvertPorcentagemToDouble(string _valor)
        =>  double.Parse(_valor.Replace("%", ""));
    
    //     Console.WriteLine(driver.Manage().Logs.ToString());

}
