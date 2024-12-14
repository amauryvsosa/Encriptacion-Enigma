using System;
using System.Text;

namespace Enigma.Encriptaciones {
    public static class BloqueDeBits {
        private const string Alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private static int Base = Alfabeto.Length;
        private static int BitsPorCaracter;
        private static int TamanoBloque;


        // Método para establecer la configuración de encriptación basica
        public static void UsarEncriptacionBasica() {
            BitsPorCaracter = 8; // Usar 8 bits por carácter para permitir más datos por bloque
            TamanoBloque = 8; // Usar bloques más grandes
        }

        // Método para establecer la configuración de encriptación avanzada
        public static void UsarEncriptacionAvanzada() {
            BitsPorCaracter = 7; // Usar 7 bits por carácter
            TamanoBloque = 6; // Tamaño de bloque optimizado para balance
        }

        // Método para verificar si el texto encriptado es válido
        public static bool EsTextoEncriptadoValido(string textoEncriptado) {
            // Se verifica que el texto encriptado solo contiene caracteres del alfabeto
            foreach (char c in textoEncriptado) {
                if (!Alfabeto.Contains(c.ToString())) {
                    return false;
                }
            }

            // Se verifica que la longitud del texto encriptado es múltiplo del tamaño de representación
            int tamanoRepresentacion = (int)Math.Ceiling(TamanoBloque * (BitsPorCaracter / Math.Log(Base, 2)));
            if (textoEncriptado.Length % tamanoRepresentacion != 0) {
                return false;
            }

            return true;
        }

        // Método para encriptar el texto
        public static string Codifica(string textoOriginal) {
            StringBuilder textoEncriptado = new StringBuilder();

            // Se procesa en bloques con el tamaño definido en la modalida para maximizar la compresion
            for (int i = 0; i < textoOriginal.Length; i += TamanoBloque) {
                // Se obtienen bloques de la cadena original
                string fragmento = textoOriginal.Substring(i, Math.Min(TamanoBloque, textoOriginal.Length - i));

                // Se convierte el fragmento a un número grande utilizando empaquetamiento de bits
                long valorNumerico = CodificarFragmento(fragmento);

                // Se convierte el número a una representación compacta en el alfabeto
                string representacion = ConvertirNumeroARepresentacion(valorNumerico);

                // Se agrega la representación al texto encriptado
                textoEncriptado.Append(representacion);
            }

            return textoEncriptado.ToString();
        }

        // Método para desencriptar el texto
        public static string Descodifica(string textoEncriptado) {
            StringBuilder textoDesencriptado = new StringBuilder();

            // Se procesa en bloques de acuerdo con el tamaño calculado del alfabeto
            int tamanoRepresentacion = (int)Math.Ceiling(TamanoBloque * (BitsPorCaracter / Math.Log(Base, 2)));
            for (int i = 0; i < textoEncriptado.Length; i += tamanoRepresentacion) {
                // Se obtiene el bloque de la representación
                string fragmento = textoEncriptado.Substring(i, Math.Min(tamanoRepresentacion, textoEncriptado.Length - i));

                // Se convierte la representación de vuelta a un número
                long valorNumerico = ConvertirRepresentacionANumero(fragmento);

                // Se convierte el número a los caracteres originales
                string fragmentoOriginal = DecodificarFragmento(valorNumerico);

                // Se agrega el fragmento original al texto desencriptado
                textoDesencriptado.Append(fragmentoOriginal);
            }

            return textoDesencriptado.ToString();
        }

        // Método para obtener el valor numerico del fragmento
        private static long CodificarFragmento(string fragmento) {
            long valorNumerico = 0;
            foreach (char c in fragmento) {
                // Se mueven los bits de valorNumerico a la izquierda para dejar espacio para el nuevo carácter
                // Luego, agregamos el valor del carácter actual a valorNumerico
                valorNumerico = (valorNumerico << BitsPorCaracter) | (c & ((1 << BitsPorCaracter) - 1));
            }
            return valorNumerico;
        }

        // Método para convertir un número la representación numerica compacta del fragmento en el alfabeto (o valores originales)
        private static string ConvertirNumeroARepresentacion(long numero) {
            StringBuilder representacion = new StringBuilder();

            // Se convierte el número a una representación compacta
            // y el valor numerico se obtiene de la posicion de la variable del alfabeto
            while (numero > 0) {
                representacion.Insert(0, Alfabeto[(int)(numero % Base)]);
                numero /= Base;
            }

            // Se valida la logitud
            while (representacion.Length < (int)Math.Ceiling(TamanoBloque * (BitsPorCaracter / Math.Log(Base, 2)))) {
                representacion.Insert(0, Alfabeto[0]);
            }

            return representacion.ToString();
        }

        // Método para convertir una representación del texto encriptado al numero respectivo
        private static long ConvertirRepresentacionANumero(string representacion) {
            long valorNumerico = 0;
            foreach (char c in representacion) {
                valorNumerico = (valorNumerico * Base) + Alfabeto.IndexOf(c);
            }
            return valorNumerico;
        }

        // Método para decodificar el numero respectivo del bloque del texto encriptado a los caracteres originales
        private static string DecodificarFragmento(long numero) {
            StringBuilder fragmento = new StringBuilder();

            // Se obtienen los caracteres originales del numero 
            while (numero > 0) {
                // Se recupera el carácter original, moviendo los bits
                char caracter = (char)(numero & ((1 << BitsPorCaracter) - 1));
                fragmento.Insert(0, caracter);
                // Se desplazan los bits del numero a la derecha para procesar el siguiente carácter
                numero >>= BitsPorCaracter;
            }

            return fragmento.ToString().TrimEnd('\0'); // Eliminar posibles rellenos nulos
        }
    }
}
