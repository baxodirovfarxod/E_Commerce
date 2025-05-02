using E_Commerce.Dal;
using E_Commerce.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repository.Repositories.CardRepository;

public class CardRepository : ICardRepository
{
    private readonly MainContext MainContext;

    public CardRepository(MainContext mainContext)
    {
        MainContext = mainContext;
    }

    public async Task AssignCardAsNotSelectedAsync(long cardId)
    {
        var card = await MainContext.Cards.FirstOrDefaultAsync(c => c.CardId == cardId);
        if (card != null)
        {
            card.SelectedForPayment = false;
            await MainContext.SaveChangesAsync();
        }
    }

    public async Task AssignCardsAsNotSelectedAsync(List<Card> cards)
    {
        if (cards == null || cards.Count == 0)
            return;

        foreach (var card in cards)
        {
            card.SelectedForPayment = false;
        }

        await MainContext.SaveChangesAsync();
    }

    public async Task AssignCardAsSelectedAsync(long cardId)
    {
        var card = await MainContext.Cards.FirstOrDefaultAsync(c => c.CardId == cardId);
        if (card != null)
        {
            card.SelectedForPayment = true;
            await MainContext.SaveChangesAsync();
        }
    }

    public  async Task DeleteCardAsync(long cardId)
    {
        var card = await MainContext.Cards.FirstOrDefaultAsync(c => c.CardId == cardId);
        if (card != null)
        {
            MainContext.Cards.Remove(card);
            await MainContext.SaveChangesAsync();
        }
    }

    public async Task<long> InsertCardAsync(Card card)
    {
        await MainContext.Cards.AddAsync(card);
        await MainContext.SaveChangesAsync();
        return card.CardId;
    }

    public async Task<List<Card>> SelectCardsByCustomerIdAsync(long customerId)
    {
        return await MainContext.Cards
            .Where(c => c.CustomerId == customerId)
            .ToListAsync();
    }

    public async Task<Card?> SelectSelectedCardByCustomerIdAsync(long customerId)
    {
        return await MainContext.Cards
                 .FirstOrDefaultAsync(c => c.CustomerId == customerId);
    }
}

