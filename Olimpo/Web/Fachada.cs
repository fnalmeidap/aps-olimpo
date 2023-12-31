using Olimpo.Controllers;
using Olimpo.Model;
using Olimpo.Repository;

namespace Olimpo.Web
{
    class Fachada
    {
        private ParticipanteController participanteController = new ParticipanteController();
        private EquipeController equipeController = new EquipeController();
        private EventoController eventoController = new EventoController();
        private TdpController tdpController = new TdpController();

        #region Login
        public Participante? logarParticipante(string tokenId)
        {
            return participanteController.Login(tokenId);
        }
        #endregion

        #region Participante
        public bool cadastrarParticipante(Participante request)
        {   
            return participanteController.CreateParticipante(request);
        }

        public Participante buscarParticipante(int Id)
        {
            return participanteController.GetParticipanteById(Id);
        }

        public IEnumerable<Participante> buscarTodosParticipantes()
        {
            return participanteController.GetParticipanteList();
        }

        public bool removerParticipante(int Id)
        {
            return participanteController.DeleteParticipanteById(Id);
        }
        #endregion

        #region Equipe
        public void cadastrarEquipe(Equipe equipe)
        {
            equipeController.CreateEquipe(equipe);
        }

        public Equipe buscarEquipe(int Id)
        {
            return equipeController.GetEquipeById(Id);
        }

        public IEnumerable<Equipe> buscarTodasEquipes()
        {
            return equipeController.GetEquipeList();
        }

        public bool cadastrarParticipanteEmEquipe(ParticipanteEquipeRequest request)
        {
            return equipeController.AddParticipanteToEquipe(request);
        }

        public bool removerEquipe(int Id)
        {
            return equipeController.DeleteEquipeById(Id);
        }
        #endregion

        #region Evento
        public void cadastrarEvento(Evento evento)
        {
            eventoController.CreateEvento(evento);
        }

        public Evento buscarEvento(int id)
        {
            return eventoController.GetEventoById(id);
        }

        public IEnumerable<Evento> buscarTodosEventos()
        {
            return eventoController.GetEventosList();
        }

        public bool inscreverEquipeEvento(InscricaoEquipeRequest request)
        {
            return eventoController.AddEquipeToEvento(request);
        }

        public bool removerEvento(int Id)
        {
            return eventoController.DeleteEventoById(Id);
        }
        #endregion

        #region Tdp
        public IEnumerable<TDP> buscarTodosTdps()
        {
            return tdpController.GetTDPList();
        }

        public TDP? buscarTdpByEquipe(int equipeId)
        {
            return tdpController.GetTDPByEquipe(equipeId);
        }

        public TDP? buscarTdpByEquipeCategoria(int equipeId, CategoriasType categoria)
        {
            return tdpController.GetTDPByEquipeCategoria(equipeId, categoria);
        }

        public bool cadastrarTdp(TDP tdp)
        {
            return tdpController.CreateTdp(tdp);
        }

        public bool removerTdp(int equipeId, CategoriasType categoria)
        {
            return tdpController.DeleteTdpById(equipeId, categoria);
        }
        #endregion
    }
}