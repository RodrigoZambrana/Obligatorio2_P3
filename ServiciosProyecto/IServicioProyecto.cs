using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiciosProyecto
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioProyecto
    {
        [OperationContract]
        IEnumerable<ProyectoDTO> todosLosproyectos();
       
        // TODO: agregue aquí sus operaciones de servicio
    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class ProyectoDTO
    {
        [DataMember]
        public string titulo { get; set; }
        [DataMember]
        public string descripcion { get; set; }
        [DataMember]
        public decimal monto { get; set; }
    }
}
