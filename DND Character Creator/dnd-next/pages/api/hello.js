export default function handler(req, res) {

  const allData = [
    {
      "race": "Dwarf",
      "description": "It's a dwarf"
    },
    {
      "race": "Human",
      "description": "It's a human"
    },
    {
      "race": "Elf",
      "description": "It's an elf"
    },
    {
      "race":"Halfling",
      "description":"It's a halfling"
    }
  ]

  res.status(200).json(allData[0])
}