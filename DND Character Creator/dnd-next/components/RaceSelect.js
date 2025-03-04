import * as React from 'react';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';

export default function RaceSelect({ raceData }) {

  const [selectedRace, setSelectedRace] = React.useState("")
  const races = raceData
  const handleChange = (event) => {
    setSelectedRace(event.target.value);
  };

  return (<FormControl sx={{ m: 1, minWidth: 120 }}>
    <InputLabel id="select-helper-label">Race</InputLabel>
    <Select
      labelId="select-helper-label"
      id="select-helper"
      value={selectedRace}
      label="Race"
      onChange={handleChange}
    >

      {races.map((race) => (
        <MenuItem
          value={race.name}
          key={race.id}
        >
          {race.name}
        </MenuItem>
      ))}

    </Select>

    <hr />
    <p>Your selected race: {selectedRace}</p>

  </FormControl>)
}

