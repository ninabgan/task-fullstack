# fullstack-oppgave

### API prosjektet

- Fungerer som grensesnittet mellom applikasjonen og det eksterne miljøet.
- Definerer kontrollere for å motta og behandle API-forespørsler.
- Inneholder program.cs filen og er prosjektet som skal kjøres for å sette opp backend

### Application prosjektet

- Inneholder applikasjonens kjernelogikk, uavhengig av eksterne rammeverk eller infrastrukturelle bekymringer.
- Implementerer forretningsregler, brukstilfeller og tjenester som definerer applikasjonens funksjonalitet.
- Kommuniserer med Entities-prosjektet for å håndtere domeneobjekter og data.
- Interagerer med Persistence-prosjektet for å lagre og hente data fra databasen eller andre datalagringsenheter.
- Ikke avhengig av spesifikke presentasjonslag eller API-implementeringer.

### Entities prosjektet

- Definerer domenemodeller som representerer applikasjonens domene.
- Beskriver strukturen til dataene som håndteres av applikasjonen.

### Persistence prosjektet

- Implementerer datalagringslogikk for å lagre og hente data fra databasen.

### Client-app

Frontend prosjektet. Inneholder en enkel søkefunksjon for brukere. Henter data fra backend gjennom et GET kall på alle brukere som per nå er et mocket kall i backend ettersom databasen ikke er oppe. Når det søkes på et navn vil det første elementet i listen presenteres i en tabell, uanvhengig av søket.

For å kjøre frontend delen må først npm install kommandoen kjøres.
