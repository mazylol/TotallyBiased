<script lang="ts">
    let title: string;
    let shorthand: string;
    let year: number;
    let rating: string;
    let runtime: string;
    let genre: string;
    let director: string;
    let actors = [];
    let thoughts: string;
    let score: number;

    function handleClick() {
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

        fetch('http://localhost:5106/api/Admin/add', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'X-Api-Key': '1234567890'
            },
            body: JSON.stringify(movie)
        });

        title = '';
        shorthand = '';
        year = 0;
        rating = '';
        runtime = '';
        genre = '';
        director = '';
        actors = [];
        thoughts = '';
        score = 0;
    }
</script>

<div class="min-h-screen bg-gray-200">
    <br />
    <p class="font-bold text-center">Add Movies</p>
    <br />
    <div class="justify-center bg-white mx-4 rounded-md">
        <input type="text" class="w-full h-12 px-4 my-1 rounded-md" placeholder="Title" bind:value={title} />
        <input type="text" class="w-full h-12 px-4 my-1 rounded-md" placeholder="Shorthand" bind:value={shorthand} />
        <input type="number" class="w-full h-12 px-4 my-1 rounded-md" placeholder="Year" bind:value={year} />
        <input type="text" class="w-full h-12 px-4 my-1 rounded-md" placeholder="Rating" bind:value={rating} />
        <input type="text" class="w-full h-12 px-4 my-1 rounded-md" placeholder="Runtime" bind:value={runtime} />
        <input type="text" class="w-full h-12 px-4 my-1 rounded-md" placeholder="Genre" bind:value={genre} />
        <input type="text" class="w-full h-12 px-4 my-1 rounded-md" placeholder="Director" bind:value={director} />
        <input type="text" class="w-full h-12 px-4 my-1 rounded-md" placeholder="Actors" bind:value={actors} />
        <input type="text" class="w-full h-12 px-4 my-1 rounded-md" placeholder="Thoughts" bind:value={thoughts} />
        <input type="number" class="w-full h-12 px-4 my-1 rounded-md" placeholder="Score" bind:value={score} />
    </div>
    <br />
    <input type="text" required class="w-full h-12 px-4 my-1 rounded-md mx-4 justify-center" placeholder="Authorization" />
    <br />
    <button class="w-full h-12 px-4 my-1 rounded-md mx-4 justify-center bg-blue-500 text-white" on:click={handleClick}>Add Movie</button>
</div>