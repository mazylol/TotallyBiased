<script lang="ts">
    let title: string;
    let shorthand: string;
    let year: number;
    let rating: string;
    let runtime: string;
    let genre: string;
    let director: string;
    let unparsedActors: string;
    let thoughts: string;
    let score: number;

    let auth: string;

    function handleClick() {
        let actors: string[] = unparsedActors?.split(',');

        const movie = {
            title,
            shorthand,
            year,
            rating,
            runtime,
            genre,
            director,
            actors,
            thoughts,
            score
        };
        console.log(movie);

        fetch('https://totallybiased-api.fly.dev/api/Admin/add', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'X-Api-Key': `${auth}`,
            },
            body: JSON.stringify(movie)
        });

        title = '';
        shorthand = '';
        year = undefined;
        rating = '';
        runtime = '';
        genre = '';
        director = '';
        unparsedActors = '';
        thoughts = '';
        score = undefined;
    }
</script>

<div class="min-h-screen bg-gray-200">
    <br/>
    <p class="font-bold text-center">Add Movies</p>
    <br/>

    <form on:submit|preventDefault={handleClick}>
        <div class="justify-center bg-white mx-4 rounded-md">
            <input type="text" class="w-full h-12 px-4 my-1 rounded-md" placeholder="Title" bind:value={title}/>
            <input type="text" class="w-full h-12 px-4 my-1 rounded-md" placeholder="Shorthand" bind:value={shorthand}/>
            <input type="number" class="w-full h-12 px-4 my-1 rounded-md" placeholder="Year" bind:value={year}/>
            <input type="text" class="w-full h-12 px-4 my-1 rounded-md" placeholder="Rating" bind:value={rating}/>
            <input type="text" class="w-full h-12 px-4 my-1 rounded-md" placeholder="Runtime" bind:value={runtime}/>
            <input type="text" class="w-full h-12 px-4 my-1 rounded-md" placeholder="Genre" bind:value={genre}/>
            <input type="text" class="w-full h-12 px-4 my-1 rounded-md" placeholder="Director" bind:value={director}/>
            <input type="text" class="w-full h-12 px-4 my-1 rounded-md" placeholder="Actors"
                   bind:value={unparsedActors}/>
            <input type="text" class="w-full h-12 px-4 my-1 rounded-md" placeholder="Thoughts" bind:value={thoughts}/>
            <input type="number" class="w-full h-12 px-4 my-1 rounded-md" placeholder="Score" bind:value={score}/>
        </div>
        <br/>
        <input type="password" required class="w-full h-12 mr-2 px-4 my-1 rounded-md mx-4 justify-center"
               placeholder="Authorization" bind:value={auth}/>
        <br/>
        <input type="submit" class="justify-center h-8 w-32 bg-blue-500 hover:bg-blue-600 transition-all duration-100 text-white"
               on:click={handleClick}/>
    </form>


</div>