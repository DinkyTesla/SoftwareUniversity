const assert = require('chai').assert;

class SoftUniFy {
    constructor() {
        this.allSongs = {};
    }

    downloadSong(artist, song, lyrics) {
        if (!this.allSongs[artist]) {
            this.allSongs[artist] = { rate: 0, votes: 0, songs: [] }
        }

        this.allSongs[artist]['songs'].push(`${song} - ${lyrics}`);

        return this;
    }

    playSong(song) {
        //Searches all already downloaded songs       accumulator, current
        let songArtists = Object.keys(this.allSongs).reduce((acc, cur) => {

            //Formats them {artist}: {song} – {lyrics}...
            let songs = this.allSongs[cur]['songs']
                .filter((songInfo) => songInfo
                    .split(/ - /)[0] === song);

            if (songs.length > 0) {
                acc[cur] = songs;
            }

            //Returns the accumulated accumulator
            return acc;
        }, {});

        let arr = Object.keys(songArtists);
        let output = "";

        if (arr.length > 0) {

            arr.forEach((artist) => {
                output += `${artist}:\n`;
                output += `${songArtists[artist].join('\n')}\n`;
            });

        } else {
            output = `You have not downloaded a ${song} song yet. Use SoftUniFy's function downloadSong() to change that!`
        }

        return output;
    }

    get songsList() {
        let songs = Object.values(this.allSongs)
            .map((v) => v['songs'])
            .reduce((acc, cur) => {
                return acc.concat(cur);
            }, []);

        let output;

        if (songs.length > 0) {
            output = songs.join('\n');
        } else {
            output = 'Your song list is empty';
        }

        return output;

    }

    rateArtist() {
        let artistExist = this.allSongs[arguments[0]];
        let output;

        if (artistExist) {

            if (arguments.length === 2) {
                artistExist['rate'] += +arguments[1];
                artistExist['votes'] += 1;
            }

            let currentRate = (+(artistExist['rate'] / artistExist['votes']).toFixed(2));
            isNaN(currentRate) ? output = 0 : output = currentRate;

        } else {
            output = `The ${arguments[0]} is not on your artist list.`
        }

        return output;
    }
}

// Unit Tests

// Positive Outcomes
describe('SoftUniFy Positive Outcomes', () => {

    // Is allSongs() an empty object
    it('Is allSongs() an empty object', () => {
        let sofunify = new SoftUniFy();
        assert.deepEqual(sofunify.allSongs, {});
    });

    //Does downloadSong(artist, song, lyrics) works correctly
    it('Does downloadSong(artist, song, lyrics) works correctly', () => {
        let sofunify = new SoftUniFy();
        sofunify.downloadSong('Eminem', 'Phenomenal', 'IM PHENOMENAL...');
        assert.equal(sofunify.allSongs['Eminem'].songs, 'Phenomenal - IM PHENOMENAL...');
    });

    // Does playsong(song) formats them {artist}: {song} - {lyrics}...
    it('Does playsong(song) formats them {artist}: {song} - {lyrics}...', () => {
        let sofunify = new SoftUniFy();
        sofunify.downloadSong('Eminem', 'Phenomenal', 'IM PHENOMENAL...');
        assert.equal(sofunify.playSong('Phenomenal'), 'Eminem:\nPhenomenal - IM PHENOMENAL...\n');
    });

});

// Negative Outcomes
describe('SoftUniFy Negative Outcomes', () => {

    // Does playsong(song) returns `You have not downloaded a {song} song yet. Use SoftUniFy's function downloadSong() to change that!`
    it('Does playsong(song) formats them {artist}: {song} - {lyrics}...', () => {
        let sofunify = new SoftUniFy();
        assert.equal(sofunify.playSong('Phenomenal'), `You have not downloaded a Phenomenal song yet. Use SoftUniFy's function downloadSong() to change that!`);
    });

    // 'Does rateArtist(Artist) returns Artist is not on your artist list.'
    it('Does rateArtist(Artist) returns Artist is not on your artist list.', () => {
        let sofunify = new SoftUniFy();
        sofunify.rateArtist('Artist')
        assert.equal(sofunify.rateArtist('Artist'), 'The Artist is not on your artist list.');
    });
});


// Init. the app
// let sofunify = new SoftUniFy();

// sofunify.downloadSong('Eminem', 'Venom', 'Knock, Knock let the devil in...');
// sofunify.downloadSong('Eminem', 'Phenomenal', 'IM PHENOMENAL...');
// sofunify.downloadSong('Dub Fx', 'Light Me On Fire', 'You can call me a liar.. ');

// console.log(sofunify.allSongs);

