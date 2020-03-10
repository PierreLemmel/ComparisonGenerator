﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComparisonGenerator.DataAccess
{
    public class RawMemoryComparandSource : IComparandSource
    {
        private static readonly IReadOnlyList<string> elements = new List<string>
        {
            "abeille",
            "abricot",
            "accident",
            "acrobate",
            "adresse",
            "adulte",
            "agneau",
            "aigle",
            "aiguille",
            "ail",
            "aile",
            "air",
            "album",
            "aliment",
            "allumette",
            "ambulance",
            "ami",
            "amour",
            "ampoule",
            "an",
            "ananas",
            "angle",
            "animal",
            "animaux",
            "anniversaire",
            "année",
            "anorak",
            "appartement",
            "appétit",
            "après-midi",
            "aquarium",
            "araignée",
            "arbre",
            "arc",
            "arc-en-ciel",
            "argent",
            "armoire",
            "arrière",
            "arrosoir",
            "arrêt",
            "arête",
            "ascenseur",
            "aspirateur",
            "assiette",
            "assiette",
            "attention",
            "auto",
            "avion",
            "aéroport",
            "bagage",
            "bagarre",
            "bague",
            "baguette",
            "bain",
            "baiser",
            "balai",
            "balançoire",
            "balcon",
            "baleine",
            "balle",
            "ballon",
            "banane",
            "banc",
            "bande",
            "barbe",
            "barque",
            "barre",
            "barreau",
            "barrette",
            "bassin",
            "bassine",
            "bateau",
            "bavoir",
            "bec",
            "beurre",
            "biberon",
            "bicyclette",
            "bifteck",
            "bijou",
            "bille",
            "billet",
            "biscuit",
            "bisou",
            "bois",
            "boisson",
            "bol",
            "bonbon",
            "bonhomme",
            "bonnet",
            "bord",
            "bosse",
            "botte",
            "botte de foin",
            "bottes",
            "bouche",
            "boucherie",
            "bouchon",
            "boue",
            "boulanger",
            "boulangerie",
            "boule",
            "bouquet",
            "bourgeon",
            "bout",
            "bouteille",
            "boutique",
            "bouton",
            "bouée",
            "boîte",
            "bracelet",
            "branche",
            "bras",
            "bretelle",
            "bricolage",
            "brosse",
            "brouette",
            "brouillard",
            "bruit",
            "buisson",
            "bulles",
            "bureau",
            "bus",
            "bâton",
            "bébé",
            "bébés",
            "bête",
            "bêtes",
            "bêtise",
            "bûche",
            "bœuf",
            "cabane",
            "cabinet",
            "cadeau",
            "cadenas",
            "cadre",
            "café",
            "cage",
            "cage à écureuil",
            "cagoule",
            "cahier",
            "caillou",
            "caisse",
            "calendrier",
            "camarade",
            "camion",
            "camp",
            "campagne",
            "canapé",
            "canard",
            "caniveau",
            "canne",
            "canne à pêche",
            "caprice",
            "caravane",
            "caresse",
            "carnet",
            "carotte",
            "carreau",
            "carrefour",
            "carton",
            "casque",
            "casquette",
            "casserole",
            "cauchemar",
            "cave",
            "ceinture",
            "cerceau",
            "cerf",
            "cerf-volant",
            "cerise",
            "chaise",
            "chaises",
            "chambre",
            "champignon",
            "chance",
            "chapeau",
            "charcuterie",
            "chasseur",
            "chaussette",
            "chemin",
            "chenille",
            "cheveu",
            "cheville",
            "chiffon",
            "chocolat",
            "chou",
            "chouette",
            "chute",
            "châtaigne",
            "château",
            "chêne",
            "ciel",
            "cigogne",
            "cil",
            "cimetière",
            "cinéma",
            "cirque",
            "citron",
            "citrouille",
            "classe",
            "clou",
            "clé",
            "clémentine",
            "coccinelle",
            "cochon d’Inde",
            "cocotte",
            "coffre",
            "coffret",
            "coin",
            "colle",
            "collier",
            "coloriage",
            "colère",
            "concombre",
            "confiture",
            "consommé",
            "copain",
            "coquetier",
            "coquillage",
            "coquille",
            "coquin",
            "corbeau",
            "corbeille",
            "corde",
            "corps",
            "cou",
            "coude",
            "couette",
            "couleur",
            "couloir",
            "coup",
            "cour",
            "course",
            "cousin",
            "cousine",
            "coussin",
            "couteau",
            "couvercle",
            "couvert",
            "craie",
            "crayon",
            "cri",
            "crochet",
            "crocodile",
            "croûte",
            "crèche",
            "crêpes",
            "cube",
            "cuillère",
            "cuillère",
            "cuisine",
            "cuisinière",
            "cuisse",
            "cuvette",
            "câlin",
            "céréale",
            "côté",
            "cœur",
            "dame",
            "danger",
            "danse",
            "dauphin",
            "dentiste",
            "dessert",
            "dessin",
            "dimanche",
            "dinosaure",
            "directeur",
            "directrice",
            "docteur",
            "doigts",
            "dos",
            "dossier",
            "douche",
            "drapeau",
            "droit",
            "début",
            "déguisement",
            "désordre",
            "dînette",
            "eau",
            "effort",
            "enfant",
            "engin",
            "entonnoir",
            "entrée",
            "envie",
            "escalier",
            "faim",
            "farce",
            "fatigue",
            "faute",
            "femme",
            "feu",
            "feuille",
            "feutre",
            "ficelle",
            "figure",
            "fil",
            "fille",
            "fils",
            "fin",
            "fièvre",
            "flaque",
            "flocon",
            "foin",
            "forêt",
            "four",
            "fourmi",
            "frein",
            "frite",
            "front",
            "frère",
            "fusée",
            "fève",
            "fête",
            "galette",
            "garage",
            "gardien",
            "gare",
            "garçon",
            "gens",
            "girafe",
            "glaçon",
            "gobelet",
            "gomme",
            "gorge",
            "gourde",
            "goutte",
            "gouttes",
            "goût",
            "graines",
            "grand-parent",
            "grimace",
            "grotte",
            "grue",
            "guirlande",
            "gâteau",
            "géant",
            "hamster",
            "herbe",
            "heure",
            "heure des mamans",
            "hibou",
            "hippopotame",
            "hirondelle",
            "hiver",
            "homme",
            "horloge",
            "humeur",
            "hélicoptère",
            "infirmier",
            "infirmière",
            "invitation",
            "jambe",
            "jambon",
            "jeudi",
            "jonquille",
            "jour",
            "journée",
            "jumeau",
            "jumelles",
            "jus",
            "kangourou",
            "kiwi",
            "lac",
            "lame",
            "langue",
            "lapin",
            "larme",
            "lion",
            "litre",
            "loup",
            "loupe",
            "luge",
            "lumière",
            "lundi",
            "lutin",
            "lèvres",
            "légume",
            "légume",
            "lézard",
            "madame",
            "maison",
            "maman",
            "marin",
            "marionnette",
            "marron",
            "marteau",
            "menton",
            "mer",
            "mine",
            "mine",
            "moto",
            "mouette",
            "moulin",
            "moustique",
            "muguet",
            "mètre",
            "médecin",
            "métal",
            "mûre",
            "mûre",
            "navire",
            "neige",
            "nez",
            "nid",
            "noyau",
            "Noël",
            "nuage",
            "orage",
            "ordonnance",
            "oreille",
            "os",
            "ouragan",
            "ours",
            "paille",
            "paix",
            "pamplemousse",
            "panda",
            "panne",
            "pansement",
            "papier",
            "papillon",
            "parapluie",
            "parasol",
            "pardon",
            "parking",
            "patte",
            "pays",
            "peinture",
            "pilote",
            "pinceau",
            "plage",
            "pluie",
            "pneu",
            "pointe",
            "poisson",
            "pomme de terre",
            "port",
            "portière",
            "potage",
            "poulet",
            "purée",
            "pâquerette",
            "pêcheur",
            "quai",
            "radis",
            "rangée",
            "rayure",
            "regard",
            "restaurant",
            "rondelle",
            "rosé",
            "râpe",
            "râteau",
            "sac",
            "sardine",
            "serviette",
            "ski",
            "sole",
            "soupe",
            "souris",
            "spectacle",
            "stylo",
            "surprise",
            "taille-crayon",
            "taupe",
            "tempête",
            "terrain",
            "terre",
            "terrier",
            "thermomètre",
            "ticket",
            "tige",
            "toit",
            "train",
            "trou",
            "vague",
            "ver",
            "virage",
            "visage",
            "vitesse",
            "voile",
            "yeux",
            "âge",
            "âne",
            "échasse",
            "éclair",
            "école",
            "écorce",
            "écriture",
            "écureuil",
            "élastique",
            "élève",
            "éléphant",
            "épingle",
            "épluchure",
            "étagère",
            "étoile",
            "étude",
            "été",
            "île",
            "œil",
        };
        private readonly Random rng = new Random();

        public async Task<string> GetComparand() => await Task.FromResult(elements[rng.Next(elements.Count)]);
    }
}