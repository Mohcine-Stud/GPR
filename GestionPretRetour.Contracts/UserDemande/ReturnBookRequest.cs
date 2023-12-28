using GestionPretRetour.Contracts.Common;

namespace GestionPretRetour.Contracts.UserDemande;

public record ReturnBookRequest(
    string UserId,
    List<Book> BooksList);

