## How to get hacking with react

Run powershell

install yarn by typing
```powershell
  npm install --global yarn
```

go to the correct directory, eg
```powershell
  # to wherever your storing this
  cd c:\dev  

  # then go inside the working directory
  cd MaddieHelloWorld  

  # then go into the dndskills subdirectory
  cd dndskills
```

now there's a bunch of things the dndskills app needs, it can automatically install all of that, just type
```powershell
  yarn
```

it'll do a bunch of one-time setup, you can ignore it more or less
now you want to launch your server to do that
```powershell
  yarn run dev
```

and it'll show you the address it's using in the powershell window.  Probably something like [http://localhost:5173/](http://localhost:5173/)

Load your browers and point it toward the address.  Then load your vscode and point it to the dndskills directory

Look at MaddieHelloWorld's `dndskills/src/DndSkillsApp.tsx` for where we were editing things

Happy hacking!  