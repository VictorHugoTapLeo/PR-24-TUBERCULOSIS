using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PR_24_TUBERCULOSIS.Tools
{
    class AnimVentanas
    {
        public static async Task Transition(Page currentPage, Page nextPage, uint duration = 250)
        {
            // Desvanecer la página actual
            await FadeOut(currentPage, duration);

            // Navegar a la nueva página
            await currentPage.Navigation.PushAsync(nextPage);

            // Desvanecer la nueva página al entrar
            await FadeIn(nextPage, duration);
        }

        public static async Task FadeOut(Page page, uint duration)
        {
            await page.FadeTo(0, duration);
        }

        public static async Task FadeIn(Page page, uint duration)
        {
            page.Opacity = 0; // Establecer opacidad a 0 antes de mostrar la página
            await page.FadeTo(1, duration);
        }
        public static async Task FadeOutContentView(ContentView contentView, uint duration)
        {
            await contentView.FadeTo(0, duration);
        }

        public static async Task FadeInContentView(ContentView contentView, uint duration)
        {
            contentView.Opacity = 0;
            await contentView.FadeTo(1, duration);
        }
    }
}
