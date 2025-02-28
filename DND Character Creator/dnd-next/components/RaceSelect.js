import * as React from 'react';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';

export default function RaceSelect() {

  const [selectedRace, setSelectedRace] = React.useState("")

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
      <MenuItem value="">
        <em>None</em>
      </MenuItem>
      <MenuItem value="dwarf">Dwarf</MenuItem>
      <MenuItem value="human">Human</MenuItem>
      <MenuItem value="elf">Elf</MenuItem>
      <MenuItem value="halfling">Halfling</MenuItem>
    </Select>
    <hr />
    <p>Your selected race: {selectedRace}</p>
  </FormControl>)
}

