using Repository;
using System.Web.Mvc;

namespace View_Web.Controllers
{
    public class TarefaController : Controller
    {
        private TarefaRepository repository;
        private CategoriaRepository categoriaRepository;
        private ProjetoRepository projetoRepository;
        private UsuarioRepository usuarioRepository;

        public TarefaController()
        {
            repository = new TarefaRepository();
            categoriaRepository = new CategoriaRepository();
            projetoRepository = new ProjetoRepository();
            usuarioRepository = new UsuarioRepository();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}