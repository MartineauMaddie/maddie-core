export const dndData = {
  "classes": {
    "total": 18,
    "last_month": 2
  },
  "responses": {
    "total": 8,
    "last_month": 2
  },
  "class_data": [
    {
      "id": 0,
      "name": "Alchemist",
      "hit_die": 8,
      "skills": 4,
      "class_skills": ["Appraise", "Craft", "Disable Device", "Fly", "Heal", "Knowledge (arcana)", "Knowledge (nature)", "Perception", "Profession", "Sleight of Hand", "Spellcraft", "Survival", "Use Magic Device"],
      "base_attack_bonus": .75,
      "fort_save_growth": "fast",
      "ref_save_growth": "fast",
      "will_save_growth": "slow"
    },
    {
      "id": 1,
      "name": "Barbarian",
      "hit_die": 12,
      "skills": 4,
      "class_skills": ["Acrobatics", "Climb", "Craft", "Handle Animal", "Intimidate", "Knowledge (nature)", "Perception", "Ride", "Survival", "Swim"],
      "base_attack_bonus": 1,
      "fort_save_growth": "fast",
      "ref_save_growth": "slow",
      "will_save_growth": "slow"
    },
    {
      "id": 2,
      "name": "Cleric",
      "hit_die": 8,
      "skills": 2,
      "class_skills": ["Appraise", "Craft", "Diplomacy", "Heal", "Knowledge (arcana)", "Knowledge (history)", "Knowledge (nobility)", "Knowledge (planes)", "Knowledge (religion)", "Linguistics", "Profession", "Sense Motive", "Spellcraft"],
      "base_attack_bonus": .75,
      "fort_save_growth": "fast",
      "ref_save_growth": "slow",
      "will_save_growth": "fast"
    }
  ],
  "race_data": [
    {
      "id": 0,
      "name": "Dwarf",
      "description": "It's a dwarf",
      "attribute_adjustment": [0, 0, 2, 0, 2, -2, 0]
    },
    {
      "id": 1,
      "name": "Human",
      "description": "It's a human",
      "attribute_adjustment": [0, 0, 0, 0, 0, 0, 2]
    },
    {
      "id": 2,
      "name": "Elf",
      "description": "It's an elf",
      "attribute_adjustment": [0, 2, -2, 2, 0, 0, 0]
    },
    {
      "id": 3,
      "name": "Halfling",
      "description": "It's a halfling",
      "attribute_adjustment": [-2, 2, 0, 0, 0, 2, 0]
    }
  ]
}