namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Models
{
    public class Sala
{
        public int Numero {get; set; }
        public int CapacidadButacas {get; set; }
        public List<Funcion> Funciones {get; set; }
        public TipoSala TipoSala {get; set; }
}
}
