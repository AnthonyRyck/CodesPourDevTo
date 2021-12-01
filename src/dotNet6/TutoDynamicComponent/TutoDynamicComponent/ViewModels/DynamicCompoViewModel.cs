using HtmlAgilityPack;

using Microsoft.AspNetCore.Components;

namespace TutoDynamicComponent.ViewModels
{
    public class DynamicCompoViewModel : IDynamicCompoViewModel
    {
        /// <see cref="IDynamicCompoViewModel.TypeCompo"/>
        public Type TypeCompo { get; private set; }

        /// <see cref="IDynamicCompoViewModel.Properties"/>
        public Dictionary<string, object> Properties { get; private set;  } = new Dictionary<string, object>();


        /// <see cref="IDynamicCompoViewModel.DisplayCounter"/>
        public void DisplayCounter()
        {
            // Ne pas oublier --> sinon Exception
            Properties.Clear();
            TypeCompo = typeof(Counter);
        }

        /// <see cref="IDynamicCompoViewModel.DisplayCompoAvecParam"/>
        public void DisplayCompoAvecParam()
        {
            // Ne pas oublier --> sinon Exception
            Properties.Clear();
            Properties.Add("UnNumero", 12);

            Utilisateur user = new Utilisateur() { Age = 24, Nom = "Ryck", Prenom = "Anthony" };
            Properties.Add("User", user);

            TypeCompo = typeof(CompoAvecParametre);
        }

        /// <see cref="IDynamicCompoViewModel.DisplayFetchDataPage"/>
        public void DisplayFetchDataPage()
        {
            // Ne pas oublier --> sinon Exception
            Properties.Clear();
            TypeCompo = typeof(FetchData);
        }

        /// <see cref="IDynamicCompoViewModel.DisplayPageWithViewModel"/>
        public void DisplayPageWithViewModel()
        {
            // Ne pas oublier --> sinon Exception
            // MARTEAU thérapie !
            Properties.Clear();
            TypeCompo = typeof(PageAvecViewModel);
        }



        public void DisplayHtml()
        {
            string urlFan = "https://fandemo.ctrl-alt-suppr.dev/FanclubPage";

            var web = new HtmlWeb();
            var doc = web.Load(urlFan);

            var nodes = doc.DocumentNode.Descendants("div")
                        .ToList()
                        .Where(x => x.Attributes.Any() && x.Attributes["class"].Value == "main")
                        .FirstOrDefault();

            Properties.Clear();
            var test = new MarkupString(nodes.InnerHtml);
            TypeCompo = typeof(test);

            //RenderFragment Display(string html) => builder =>
            //{
            //
            //    builder.AddContent(0, new MarkupString(html));
            //};
            //
            //DisplayRenderFragment = Display(nodes.InnerHtml);
        }

    }
}
