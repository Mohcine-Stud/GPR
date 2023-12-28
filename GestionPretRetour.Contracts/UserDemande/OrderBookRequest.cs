using GestionPretRetour.Contracts.Common;

namespace GestionPretRetour.Contracts.UserDemande;

public record OrderBookRequest(
    string UserId,
    List<Book> BooksList
    );
