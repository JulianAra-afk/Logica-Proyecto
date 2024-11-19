using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Serivicios.Entity;

namespace Serivicios.Services{
    public class UsuarioService{
        
        private readonly HttpClient _httpClient;

        public UsuarioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Usuario>> GetAllUsuariosAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:8080/api/Usuario");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Usuario>>();
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:8080/api/Usuario/{id}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<Usuario>();
            return null;
        }

        public async Task CreateUsuarioAsync(Usuario Usuario)
        {
            var url = "http://localhost:8080/api/Usuario";
            var contenidoJson = JsonConvert.SerializeObject(Usuario);

            var content = new StringContent(contenidoJson, Encoding.UTF8, "application/json");

            // Usando el objeto MediaTypeHeaderValue para establecer el tipo de contenido correctamente
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.PostAsync(url, content);

            response.EnsureSuccessStatusCode();
        }

        public async Task<bool> UpdateUsuarioAsync(Usuario Usuario)
        {
            var url = $"http://localhost:8080/api/Usuario/{Usuario.UsuarioId}";  // URL de la API con el ID de la Usuario

            var contenidoJson = JsonConvert.SerializeObject(Usuario);  // Serializamos el objeto Entity a JSON
            var content = new StringContent(contenidoJson, Encoding.UTF8, "application/json");  // Creamos el StringContent

            // Usamos el objeto MediaTypeHeaderValue para establecer el tipo de contenido
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Realizamos la solicitud PUT para actualizar la Usuario
            var response = await _httpClient.PutAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                return true;  // Actualización exitosa
            }
            return false;  // Si algo salió mal, retornamos false
        }

        public async Task<bool> DeleteUsuarioAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:8080/api/Usuario/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}