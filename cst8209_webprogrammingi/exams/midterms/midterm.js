// Section A

class Concert {
  constructor(artist, year, songs, attended) {
    this.artist = artist;
    this.year = year;
    this.songs = songs;
    this.attended = attended;
  }

  numberOfSongs() {
    return this.songs.length;
  }

  render() {
    return `
    <strong>Year:</strong> ${this.year}<br />
    <strong>Artist:</strong> ${this.artist}<br />
    <strong>Number of Songs:</strong> ${this.numberOfSongs()}<br />
    <strong>Attended:</strong> ${this.attended ? "Yes" : "No"}<br />
    <hr />
`;
  }
}

// Section B

const concerts = [
  new Concert("Taylor Swift", 2019, [
    "Clean",
    "Reputation",
    "The 1"
  ], true),

  new Concert("Green Day", 2020, [
    "Wake Me Up When September Ends",
    "Boulevard of Broken Dreams",
  ], false),

  new Concert("Avril Lavigne", 2017, [
    "Complicated",
  ], false)
];

function renderAllResults(concertList) {
  const allResultsDiv = document.getElementById("allResults");
  allResultsDiv.innerHTML = "";

  for (let i = 0; i < concertList.length; i++) {
    const concertDiv = document.createElement("div");
    concertDiv.innerHTML = concertList[i].render();

    allResultsDiv.appendChild(concertDiv);
  }
}

renderAllResults(concerts);


// Section C

function renderProcessedResults(concertList) {
  const processedResultsDiv = document.getElementById("processedResults");
  processedResultsDiv.innerHTML = "";

  for (let i = 0; i < concertList.length; i++) {
    const concertDiv = document.createElement("div");
    concertDiv.innerHTML = concertList[i].render();

    processedResultsDiv.appendChild(concertDiv);
  }
}

renderProcessedResults(concerts);


// if value = 0: sort year in ascending order
// if value = 1: sort year in descending order
// if value = 2: filter artist name
function sortOrFilter(val) {
  switch (val) {
    case 0:
      renderProcessedResults([...concerts].sort(sortYearAscending));
      break;
    case 1:
      renderProcessedResults([...concerts].sort(sortYearDescending));
      break;
    case 2:
      const filterValue = document.getElementById("filterByArtistName").value;
      const regexRule = new RegExp(filterValue, "gmi");

      renderProcessedResults([...concerts].filter(function(concert) {
        return concert.artist.match(regexRule);
      }));
      break;
  }
}


let sortYearBy = "not used";
let filterByArtistName = "";

// Modified version of sortOrFilter, with filter permanence.
//
// if value = 0: sort year in ascending order
// if value = 1: sort year in descending order
// if value = 2: filter artist name
function sortOrFilter2(val) {
  switch (val) {
    case 0:
      sortYearBy = "ascending";
      break;
    case 1:
      sortYearBy = "descending";
      break;
    case 2:
      filterByArtistName = document.getElementById("filterByArtistName").value;
      break;
  }

  const regexRule = new RegExp(filterByArtistName, "gmi");
  const results = [...concerts].filter(function(concert) {
    if (filterByArtistName === "") return true;

    return concert.artist.match(regexRule);
  });

  if (sortYearBy === "ascending") {
    results.sort(sortYearAscending);
  } else if (sortYearBy === "descending") {
    results.sort(sortYearDescending);
  }

  renderProcessedResults(results);
}

function sortYearAscending(a, b) {
  if (a.year < b.year) {
    return -1;
  }
  if (a.year > b.year) {
    return 1;
  }
  return 0;
}

function sortYearDescending(a, b) {
  if (a.year < b.year) {
    return 1;
  }
  if (a.year > b.year) {
    return -1;
  }
  return 0;
}
