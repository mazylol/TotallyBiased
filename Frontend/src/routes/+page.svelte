<script lang="ts">
    import axios from "axios";


    let visible = false;

    let shorthand: string;
    let lastShorthand: string;

    function toggle() {
        visible = !visible;
    }

    class Movie {
        static id: string;
        static shorthand: string;
        static title: string;
        static year: number;
        static rating: string;
        static runtime: string;
        static genre: string;
        static director: string;
        static actors: string[];
        static thoughts: string;
        static score: number;

    }

    async function search() {
        if (shorthand == lastShorthand) {
            return;
        }

        try {
            const response = await axios.get('https://totallybiased-api.fly.dev/api/Movie', {
                params: {
                    shorthand: shorthand
                }
            });

            Movie.id = response.data.id;
            Movie.shorthand = response.data.shorthand;
            Movie.title = response.data.title;
            Movie.year = response.data.year;
            Movie.rating = response.data.rating;
            Movie.runtime = response.data.runtime;
            Movie.genre = response.data.genre;
            Movie.director = response.data.director;
            Movie.actors = response.data.actors;
            Movie.thoughts = response.data.thoughts;
            Movie.score = response.data.score;

            return response.data;
        } catch (error) {
            console.error(error)
        }

        lastShorthand = shorthand;
    }
</script>

<div class="flex flex-col items-center justify-center">
    <form on:submit|once={toggle} on:submit|preventDefault={search}>
        <input type="text" placeholder="Shorthand"
               class="text-md text-gray-base w-96 mr-3 py-5 px-4 h-2 border border-gray-200 rounded mb-2 mt-16 rounded-xl shadow-sm"
               required bind:value={shorthand}/>
        <button type="submit" class="bg-blue-500 text-white w-16 rounded-xl h-10 font-bold">Search</button>
    </form>
</div>

{#if visible}
    <div class="mx-auto w-64 bg-white rounded-xl shadow-xl">
        <p class="text-center text-2xl font-bold">{Movie.title}</p>
        <p class="text-center text-sm font-thin border-b-2 border-dotted border-gray-300">{Movie.year} &#x2022; {Movie.rating}</p>
        <div class="mx-2 mt-2">
            <p>Runtime: {Movie.runtime}</p>
            <p>Genre: {Movie.genre}</p>
            <p>Director: {Movie.director}</p>
            <p>Actors:</p>
            <ul>
                {#if Movie.actors}
                    {#each Movie.actors as actor}
                    <li class="ml-4 list-disc">{actor}</li>
                {/each}
                {/if}
            </ul>
            <p>Thoughts: {Movie.thoughts}</p>
            <p>Score: {Movie.score}</p>
        </div>
    </div>
{/if}