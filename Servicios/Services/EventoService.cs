using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Serivicios.Entity;

namespace Serivicios.Services
{
    public class EventoService
    {

        private readonly HttpClient _httpClient;

        public EventoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Evento>> GetAllEventosAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:8080/api/Evento");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Evento>>();
        }

        public async Task<Evento> GetEventoByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:8080/api/Evento/{id}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<Evento>();
            return null;
        }

        public async Task CreateEventoAsync(Evento Evento)
        {
            var url = "http://localhost:8080/api/Evento";
            var contenidoJson = JsonConvert.SerializeObject(Evento);

            var content = new StringContent(contenidoJson, Encoding.UTF8, "application/json");

            // Usando el objeto MediaTypeHeaderValue para establecer el tipo de contenido correctamente
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.PostAsync(url, content);

            response.EnsureSuccessStatusCode();
        }

        public async Task<bool> UpdateEventoAsync(Evento Evento)
        {
            var url = $"http://localhost:8080/api/Evento{Evento.EventoId}";  // URL de la API con el ID de la Evento

            var contenidoJson = JsonConvert.SerializeObject(Evento);  // Serializamos el objeto Entity a JSON
            var content = new StringContent(contenidoJson, Encoding.UTF8, "application/json");  // Creamos el StringContent

            // Usamos el objeto MediaTypeHeaderValue para establecer el tipo de contenido
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Realizamos la solicitud PUT para actualizar la Evento
            var response = await _httpClient.PutAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                return true;  // Actualización exitosa
            }
            return false;  // Si algo salió mal, retornamos false
        }

        public async Task<bool> DeleteEventoAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:8080/api/Evento({id}");
            return response.IsSuccessStatusCode;
        }
    }
}
