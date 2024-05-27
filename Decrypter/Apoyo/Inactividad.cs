using System;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace Enigma.Apoyo {
    public static class Inactividad {
        public static Timer TiempoInactividad {  get; set; }
        private static readonly int TIEMPO_CONSIDERADO_INACTIVO = 300000;

        public static void IniciarContadorActividad(EventHandler eventoTick) {
            TiempoInactividad = new Timer {
                Interval = TIEMPO_CONSIDERADO_INACTIVO
            };

            TiempoInactividad.Tick += eventoTick;
            TiempoInactividad.Start();
        }

        public static void CapturarClicks(ControlCollection controles, EventHandler evento) {
            foreach(Control control in controles) {
                control.Click += evento;

                if(control.HasChildren) {
                    CapturarClicks(control.Controls, evento);
                }
            }
        }
    }
}
