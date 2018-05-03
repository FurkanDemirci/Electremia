using System.Collections.Generic;

namespace Electremia.ViewModels
{
    public class RequestsViewModel
    {
        public List<RelationshipViewModel> RelationshipViewModelsPending { get; set; }
        public List<RelationshipViewModel> RelationshipViewModelsSended { get; set; }

        public RequestsViewModel()
        {
            RelationshipViewModelsPending = new List<RelationshipViewModel>();
            RelationshipViewModelsSended = new List<RelationshipViewModel>();
        }
    }
}