using System.ComponentModel.DataAnnotations;

namespace TASKWAVE.DTO.Requests
{
    public class SetorRequest
    {
        public int sectorId { get; set; }

        [Required(ErrorMessage = "O nome do setor é obrigatório.")]
        public string sectorName { get; set; }

        [Required(ErrorMessage = "A descrição do setor é obrigatória.")]
        public string sectorDescription { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Selecione um ambiente válido.")]
        public int environmentId { get; set; }
    }
}