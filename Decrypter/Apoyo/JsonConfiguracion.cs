using System.Collections.Generic;

namespace Enigma.Apoyo {

    public class JsonPorDefecto {
        private readonly JsonConfiguracion primerJson = null;
        public JsonPorDefecto() {
            primerJson = new JsonConfiguracion {
                EncriptacionesDisponibles = new List<DatosEncriptacion>()
            };

            DatosEncriptacion Base64 = new DatosEncriptacion {
                Nombre = "Base64",
                NombreComun = "Encriptacion Normal",
                Id = 1
            };

            DatosEncriptacion Aes = new DatosEncriptacion {
                Nombre = "AES",
                NombreComun = "Encriptacion Nuget",
                Id = 2,
                Propiedades = new DatosPropiedades {
                    LlaveEncriptado = "E546C8DF278CD5931069B522E695D4F2"
                }
            };

            DatosEncriptacion Rsa = new DatosEncriptacion {
                Nombre = "RSA",
                NombreComun = "Encriptacion Devglan",
                Id = 3,
                Propiedades = new DatosPropiedades {
                    LongitudesLlave = new List<int> { 515, 1024, 2048, 3072, 4096 },
                    TiposCifrados = new List<string> { "RSA/ECB/PKCS1Padding", "RSA/ECB/OAEPWithSHA-1AndMGF1Padding", "RSA/ECB/OAEPWithSHA-256AndMGF1Padding" },
                    LlavePublica = string.Empty,
                    LlavePrivada = string.Empty
                }
            };

            primerJson.EncriptacionesDisponibles.Add(Base64);
            primerJson.EncriptacionesDisponibles.Add(Aes);
            primerJson.EncriptacionesDisponibles.Add(Rsa);
        }

        public JsonConfiguracion ObtenerJsonBienvenida() {
            return primerJson;
        }
    }

    public class JsonConfiguracion {
        public List<DatosEncriptacion> EncriptacionesDisponibles { get; set; }
    }

    public class DatosEncriptacion {
        public string Nombre { get; set; }
        public string NombreComun { get; set; }
        public int Id { get; set; }
        public DatosPropiedades Propiedades { get; set; }
    }
    public class DatosPropiedades {
        public string LlaveEncriptado { get; set; }
        public List<int> LongitudesLlave { get; set; }
        public List<string> TiposCifrados { get; set; }
        public string LlavePublica { get; set; }
        public string LlavePrivada { get; set; }
    }
}
