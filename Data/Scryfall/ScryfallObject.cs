// ReSharper disable ClassNeverInstantiated.Global

// ReSharper disable StringLiteralTypo
// ReSharper disable IdentifierTypo

using System.Text.Json.Serialization;

namespace JMPPAD.Data.Scryfall;

public class ScryfallObject
{
    // CardObject myDeserializedClass = JsonConvert.DeserializeObject<CardObject>?(myJsonResponse);

    #region Card Objects

    public class CardObject
    {
        [JsonPropertyName("object")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Object { get; set; }

        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Id { get; set; } = null!;

        [JsonPropertyName("oracle_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? OracleId { get; set; }

        [JsonPropertyName("multiverse_ids")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<int>? MultiverseIds { get; set; }

        [JsonPropertyName("mtgo_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MtgoId { get; set; }

        [JsonPropertyName("mtgo_foil_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MtgoFoilId { get; set; }

        [JsonPropertyName("tcgplayer_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TcgplayerId { get; set; }

        [JsonPropertyName("cardmarket_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? CardmarketId { get; set; }

        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Name { get; set; }

        [JsonPropertyName("lang")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Lang { get; set; }

        [JsonPropertyName("released_at")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ReleasedAt { get; set; }

        [JsonPropertyName("uri")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Uri { get; set; }

        [JsonPropertyName("scryfall_uri")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ScryfallUri { get; set; }

        [JsonPropertyName("layout")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Layout { get; set; }

        [JsonPropertyName("highres_image")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? HighresImage { get; set; }

        [JsonPropertyName("image_status")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ImageStatus { get; set; }

        [JsonPropertyName("image_uris")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ImageUris? ImageUris { get; set; }

        [JsonPropertyName("mana_cost")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ManaCost { get; set; }

        [JsonPropertyName("cmc")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Cmc { get; set; }

        [JsonPropertyName("type_line")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? TypeLine { get; set; }

        [JsonPropertyName("oracle_text")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? OracleText { get; set; }

        [JsonPropertyName("power")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Power { get; set; }

        [JsonPropertyName("toughness")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Toughness { get; set; }

        [JsonPropertyName("colors")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? Colors { get; set; }

        [JsonPropertyName("color_identity")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? ColorIdentity { get; set; }

        [JsonPropertyName("keywords")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<object>? Keywords { get; set; }

        [JsonPropertyName("legalities")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Legalities? Legalities { get; set; }

        [JsonPropertyName("games")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? Games { get; set; }

        [JsonPropertyName("reserved")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Reserved { get; set; }

        [JsonPropertyName("foil")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Foil { get; set; }

        [JsonPropertyName("nonfoil")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Nonfoil { get; set; }

        [JsonPropertyName("finishes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? Finishes { get; set; }

        [JsonPropertyName("oversized")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Oversized { get; set; }

        [JsonPropertyName("promo")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Promo { get; set; }

        [JsonPropertyName("reprint")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Reprint { get; set; }

        [JsonPropertyName("variation")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Variation { get; set; }

        [JsonPropertyName("set_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SetId { get; set; }

        [JsonPropertyName("set")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Set { get; set; }

        [JsonPropertyName("set_name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SetName { get; set; }

        [JsonPropertyName("set_type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SetType { get; set; }

        [JsonPropertyName("set_uri")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SetUri { get; set; }

        [JsonPropertyName("set_search_uri")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SetSearchUri { get; set; }

        [JsonPropertyName("scryfall_set_uri")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ScryfallSetUri { get; set; }

        [JsonPropertyName("rulings_uri")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? RulingsUri { get; set; }

        [JsonPropertyName("prints_search_uri")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? PrintsSearchUri { get; set; }

        [JsonPropertyName("collector_number")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? CollectorNumber { get; set; }

        [JsonPropertyName("digital")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Digital { get; set; }

        [JsonPropertyName("rarity")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Rarity { get; set; }

        [JsonPropertyName("flavor_text")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? FlavorText { get; set; }

        [JsonPropertyName("card_back_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? CardBackId { get; set; }

        [JsonPropertyName("artist")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Artist { get; set; }

        [JsonPropertyName("artist_ids")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? ArtistIds { get; set; }

        [JsonPropertyName("illustration_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? IllustrationId { get; set; }

        [JsonPropertyName("border_color")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? BorderColor { get; set; }

        [JsonPropertyName("frame")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Frame { get; set; }

        [JsonPropertyName("full_art")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? FullArt { get; set; }

        [JsonPropertyName("textless")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Textless { get; set; }

        [JsonPropertyName("booster")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Booster { get; set; }

        [JsonPropertyName("story_spotlight")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? StorySpotlight { get; set; }

        [JsonPropertyName("edhrec_rank")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? EdhrecRank { get; set; }

        [JsonPropertyName("penny_rank")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? PennyRank { get; set; }

        [JsonPropertyName("prices")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Prices? Prices { get; set; }

        [JsonPropertyName("related_uris")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public RelatedUris? RelatedUris { get; set; }

        [JsonPropertyName("all_parts")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<AllPart>? AllParts { get; set; }

        [JsonPropertyName("security_stamp")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SecurityStamp { get; set; }

        [JsonPropertyName("card_faces")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<ObjectFace>? CardFaces { get; set; }

        [JsonPropertyName("loyalty")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Loyalty { get; set; }
    }

    public class AllPart
    {
        [JsonPropertyName("object")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Object { get; set; }

        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Id { get; set; }

        [JsonPropertyName("component")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Component { get; set; }

        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Name { get; set; }

        [JsonPropertyName("type_line")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? TypeLine { get; set; }

        [JsonPropertyName("uri")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Uri { get; set; }
    }

    public class ObjectFace
    {
        [JsonPropertyName("object")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Object { get; set; }

        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Name { get; set; }

        [JsonPropertyName("mana_cost")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ManaCost { get; set; }

        [JsonPropertyName("type_line")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? TypeLine { get; set; }

        [JsonPropertyName("oracle_text")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? OracleText { get; set; }

        [JsonPropertyName("colors")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? Colors { get; set; }

        [JsonPropertyName("color_indicator")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? ColorIndicator { get; set; }

        [JsonPropertyName("flavor_text")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? FlavorText { get; set; }

        [JsonPropertyName("artist")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Artist { get; set; }

        [JsonPropertyName("artist_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ArtistId { get; set; }

        [JsonPropertyName("illustration_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? IllustrationId { get; set; }

        [JsonPropertyName("image_uris")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ImageUris? ImageUris { get; set; }

        [JsonPropertyName("flavor_name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? FlavorName { get; set; }

        [JsonPropertyName("loyalty")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Loyalty { get; set; }

        [JsonPropertyName("power")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Power { get; set; }

        [JsonPropertyName("toughness")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Toughness { get; set; }
    }

    public class ImageUris
    {
        [JsonPropertyName("small")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Small { get; set; }

        [JsonPropertyName("normal")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Normal { get; set; }

        [JsonPropertyName("large")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Large { get; set; }

        [JsonPropertyName("png")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Png { get; set; }

        [JsonPropertyName("art_crop")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ArtCrop { get; set; }

        [JsonPropertyName("border_crop")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? BorderCrop { get; set; }
    }

    public class Legalities
    {
        [JsonPropertyName("standard")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Standard { get; set; }

        [JsonPropertyName("future")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Future { get; set; }

        [JsonPropertyName("historic")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Historic { get; set; }

        [JsonPropertyName("gladiator")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Gladiator { get; set; }

        [JsonPropertyName("pioneer")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Pioneer { get; set; }

        [JsonPropertyName("explorer")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Explorer { get; set; }

        [JsonPropertyName("modern")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Modern { get; set; }

        [JsonPropertyName("legacy")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Legacy { get; set; }

        [JsonPropertyName("pauper")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Pauper { get; set; }

        [JsonPropertyName("vintage")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Vintage { get; set; }

        [JsonPropertyName("penny")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Penny { get; set; }

        [JsonPropertyName("commander")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Commander { get; set; }

        [JsonPropertyName("brawl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Brawl { get; set; }

        [JsonPropertyName("historicbrawl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Historicbrawl { get; set; }

        [JsonPropertyName("alchemy")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Alchemy { get; set; }

        [JsonPropertyName("paupercommander")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Paupercommander { get; set; }

        [JsonPropertyName("duel")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Duel { get; set; }

        [JsonPropertyName("oldschool")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Oldschool { get; set; }

        [JsonPropertyName("premodern")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Premodern { get; set; }
    }

    public class Prices
    {
        [JsonPropertyName("usd")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Usd { get; set; }

        [JsonPropertyName("usd_foil")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? UsdFoil { get; set; }

        [JsonPropertyName("usd_etched")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object? UsdEtched { get; set; }

        [JsonPropertyName("eur")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Eur { get; set; }

        [JsonPropertyName("eur_foil")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? EurFoil { get; set; }

        [JsonPropertyName("tix")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Tix { get; set; }
    }

    public class RelatedUris
    {
        [JsonPropertyName("gatherer")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Gatherer { get; set; }

        [JsonPropertyName("tcgplayer_infinite_articles")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? TcgplayerInfiniteArticles { get; set; }

        [JsonPropertyName("tcgplayer_infinite_decks")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? TcgplayerInfiniteDecks { get; set; }

        [JsonPropertyName("edhrec")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Edhrec { get; set; }
    }

    #endregion

    #region Bulk Data Objects

    public class BulkData
    {
        [JsonPropertyName("object")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Object { get; set; }

        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Id { get; set; }

        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Type { get; set; }

        [JsonPropertyName("updated_at")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? UpdatedAt { get; set; }

        [JsonPropertyName("uri")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Uri { get; set; }

        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Description { get; set; }

        [JsonPropertyName("compressed_size")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? CompressedSize { get; set; }

        [JsonPropertyName("download_uri")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? DownloadUri { get; set; }

        [JsonPropertyName("content_type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ContentType { get; set; }

        [JsonPropertyName("content_encoding")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ContentEncoding { get; set; }
    }

    #endregion
    
    public class SymbolObject
    {
        public class RootObject
        {
            [JsonPropertyName("data")]
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public DataObject[]? ObjectData { get; set; }
        }

        public class DataObject
        {
            [JsonPropertyName("symbol")]
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string? Symbol { get; set; }

            [JsonPropertyName("svg_uri")]
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string? SvgUri { get; set; }

            [JsonPropertyName("loose_variant")]
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string? LooseVariant { get; set; }

            [JsonPropertyName("english")]
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string? English { get; set; }

            [JsonPropertyName("transposable")]
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public bool Transposable { get; set; }

            [JsonPropertyName("represents_mana")]
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public bool RepresentsMana { get; set; }

            [JsonPropertyName("appears_in_mana_costs")]
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public bool AppearsInManaCosts { get; set; }

            [JsonPropertyName("cmc")]
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public double? Cmc { get; set; }

            [JsonPropertyName("funny")]
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public bool Funny { get; set; }
        }
    }
}