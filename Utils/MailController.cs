using System.Text;
using System.Text.Json;
using Backend.Models;

namespace Backend.Utils;

public class MailController{
    public async void EnviarCorreo(string userEmail, string userName, string tokenAuthorization){

        /* Inicializar variable, URL de destino para la solicitud POST de la API Mailsersend*/
        string url = "https://api.mailersend.com/v1/email";

        /* Token de autorizacion para la solicitud: */
        string tokenEmail = "mlsn.dac567a731075e03630dd7040b67e9ddaead36cf0ca945e15cf9f1ccbbc7ec00";

        /* Se crea una instancia de la clase Email para contener el mensaje */
        var emailMessage = new Email{
            from = new From {email = "MS_bOkQGp@trial-z86org8od2z4ew13.mlsender.net"},
            to = [
                new To {email = userEmail}
            ],
            subject = "TOKEN OF MINIDRIVE",
            text = $"¡User {userName}, this is your token: {tokenAuthorization}\n¡This token will expire in 10 minutes!",
            html = $"¡User {userName}, this is your token: {tokenAuthorization}\n¡This token will expire in 10 minutes!"
        };


        /* Serializar el objeto emailMessage en formato JSON: */
        string jsonBody = JsonSerializer.Serialize(emailMessage);

        /* Crear un objeto HTTPClient para realuzar la solicitud HTTP */
        using(HttpClient client = new HttpClient()){
            /* Configurar el encabezado de Authorization para indicar el token de autorizacion */
            /* client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenEmail); */
            client.DefaultRequestHeaders.Add("ContentType", "application/json");
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {tokenEmail}");

            /* Crear el contenido de la silicitus POST como StringContent: */
            StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            /* Realizar la solicitud POST a la URL indicada: */
            HttpResponseMessage response = await client.PostAsync(url,content);

            /* Se confirma si la solicitud fue éxitoso (codigo de estado: 200 - 209) */
            if(response.IsSuccessStatusCode){
                Console.WriteLine($"Estado de la solicitud: {response.StatusCode}");
            }
            else{
                /* Si la solicitud no sue éxitosa, se muestra el estado de la solicitud:  */
                Console.WriteLine($"La solicitud falló con el código de estado: {response.StatusCode}");
            }

        }



    } 
}