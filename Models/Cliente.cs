namespace api.examenparcial1.Models
{
    public class Cliente
    {
        public int id { get; set; }

        public int idCiudad { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string Documento { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Ciudad { get; set; }

        public string Nacionalidad { get; set; }


    }
}
