using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace APIIntegrationTestsExample.Controllers
{

    public class PokemonInfo
    {

        [JsonProperty("abilities")]
        public List<Ability> Abilities { get; set; }

        [JsonProperty("base_experience")]
        public long BaseExperience { get; set; }

        [JsonProperty("forms")]
        public List<Species> Forms { get; set; }

        [JsonProperty("game_indices")]
        public List<GameIndex> GameIndices { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("held_items")]
        public List<HeldItem> HeldItems { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }

        [JsonProperty("location_area_encounters")]
        public Uri LocationAreaEncounters { get; set; }

        [JsonProperty("moves")]
        public List<Move> Moves { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("order")]
        public long Order { get; set; }

        [JsonProperty("species")]
        public Species Species { get; set; }

        [JsonProperty("sprites")]
        public Sprites Sprites { get; set; }

        [JsonProperty("stats")]
        public List<Stat> Stats { get; set; }

        [JsonProperty("types")]
        public List<TypeElement> Types { get; set; }

        [JsonProperty("weight")]
        public long Weight { get; set; }
    }

    public partial class Ability
    {
        [JsonProperty("ability")]
        public Species AbilityAbility { get; set; }

        [JsonProperty("is_hidden")]
        public bool IsHidden { get; set; }

        [JsonProperty("slot")]
        public long Slot { get; set; }
    }

    public partial class Species
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public partial class GameIndex
    {
        [JsonProperty("game_index")]
        public long GameIndexGameIndex { get; set; }

        [JsonProperty("version")]
        public Species Version { get; set; }
    }

    public partial class HeldItem
    {
        [JsonProperty("item")]
        public Species Item { get; set; }

        [JsonProperty("version_details")]
        public List<VersionDetail> VersionDetails { get; set; }
    }

    public partial class VersionDetail
    {
        [JsonProperty("rarity")]
        public long Rarity { get; set; }

        [JsonProperty("version")]
        public Species Version { get; set; }
    }

    public partial class Move
    {
        [JsonProperty("move")]
        public Species MoveMove { get; set; }

        [JsonProperty("version_group_details")]
        public List<VersionGroupDetail> VersionGroupDetails { get; set; }
    }

    public partial class VersionGroupDetail
    {
        [JsonProperty("level_learned_at")]
        public long LevelLearnedAt { get; set; }

        [JsonProperty("move_learn_method")]
        public Species MoveLearnMethod { get; set; }

        [JsonProperty("version_group")]
        public Species VersionGroup { get; set; }
    }

    public partial class Sprites
    {
        [JsonProperty("back_default")]
        public Uri BackDefault { get; set; }

        [JsonProperty("back_female")]
        public Uri BackFemale { get; set; }

        [JsonProperty("back_shiny")]
        public Uri BackShiny { get; set; }

        [JsonProperty("back_shiny_female")]
        public Uri BackShinyFemale { get; set; }

        [JsonProperty("front_default")]
        public Uri FrontDefault { get; set; }

        [JsonProperty("front_female")]
        public Uri FrontFemale { get; set; }

        [JsonProperty("front_shiny")]
        public Uri FrontShiny { get; set; }

        [JsonProperty("front_shiny_female")]
        public Uri FrontShinyFemale { get; set; }
    }

    public partial class Stat
    {
        [JsonProperty("base_stat")]
        public long BaseStat { get; set; }

        [JsonProperty("effort")]
        public long Effort { get; set; }

        [JsonProperty("stat")]
        public Species StatStat { get; set; }
    }

    public partial class TypeElement
    {
        [JsonProperty("slot")]
        public long Slot { get; set; }

        [JsonProperty("type")]
        public Species Type { get; set; }
    }



}