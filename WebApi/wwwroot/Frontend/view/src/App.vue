<template>

  <div class="w-full px-4 overflow-x-hidden flex flex-col">
    <div class=" sm:-mx-6 lg:-mx-8">
      <div class=" inline-block min-w-full">
        <div class="">

          <div class="flex items-center justify-between px-10 bg-gray-100">
            <div class="my-auto">
              <button id="dropdownRadioButton" data-dropdown-toggle="dropdownRadio"
                class="inline-flex items-center text-gray-500 bg-white border border-gray-300 focus:outline-none hover:bg-gray-100 focus:ring-4 focus:ring-gray-200 font-medium rounded-lg text-sm px-3 py-1.5 dark:bg-gray-800 dark:text-white dark:border-gray-600 dark:hover:bg-gray-700 dark:hover:border-gray-600 dark:focus:ring-gray-700"
                type="button">
                <svg class="w-4 h-4 mr-2 text-gray-400" aria-hidden="true" fill="currentColor" viewBox="0 0 20 20"
                  xmlns="http://www.w3.org/2000/svg">
                  <path fill-rule="evenodd"
                    d="M10 18a8 8 0 100-16 8 8 0 000 16zm1-12a1 1 0 10-2 0v4a1 1 0 00.293.707l2.828 2.829a1 1 0 101.415-1.415L11 9.586V6z"
                    clip-rule="evenodd"></path>
                </svg>
                <div v-if="SelectFilter">
                  {{ SelectFilter.Name }}
                </div>
                <div v-else>
                  Сортировка
                </div>
                <svg class="w-3 h-3 ml-2" aria-hidden="true" fill="none" stroke="currentColor" viewBox="0 0 24 24"
                  xmlns="http://www.w3.org/2000/svg">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 9l-7 7-7-7"></path>
                </svg>
              </button>

              <!-- Dropdown menu -->
              <div id="dropdownRadio"
                class="z-10 hidden w-48 bg-white divide-y divide-gray-100 rounded-lg shadow dark:bg-gray-700 dark:divide-gray-600"
                data-popper-reference-hidden="" data-popper-escaped="" data-popper-placement="top"
                style="position: absolute; inset: auto auto 0px 0px; margin: 0px; transform: translate3d(522.5px, 3847.5px, 0px);">
                <ul class="p-3 space-y-1 text-sm text-gray-700 dark:text-gray-200"
                  aria-labelledby="dropdownRadioButton">
                  <li v-for="el in Filters" :key="el.index">
                    <div class="text-start whitespace-pre p-2 rounded hover:bg-gray-100 dark:hover:bg-gray-600">
                      <input @click="AcceptFilter(el)" id="filter-radio-example-1" type="radio" value=""
                        name="filter-radio"
                        class="w-4 h-4 text-blue-600 bg-gray-100 border-gray-300 focus:ring-blue-500 dark:focus:ring-blue-600 dark:ring-offset-gray-800 dark:focus:ring-offset-gray-800 focus:ring-2 dark:bg-gray-700 dark:border-gray-600">
                      <label class="w-full ml-2 text-sm font-medium text-gray-900 rounded dark:text-gray-300">{{
                        el.Name
                      }}</label>
                    </div>
                  </li>
                  <li>
                    <div @click="UpdateList()" class="hover:cursor-pointer hover:text-red-500 text-start text-xs text-gray-300">
                      Сбросить фильтр
                    </div>
                  </li>


                </ul>
              </div>
            </div>
            <form class="mt-4" @submit.prevent="Search">
              <div class="flex">
                <div class="relative w-full">
                  <input v-model="SearchText.text" type="search" id="search-dropdown"
                    class="block p-2.5 w-full z-20 text-sm text-gray-900 bg-gray-50 rounded-r-lg border-l-gray-50 border border-gray-300 focus:ring-blue-500 focus:border-blue-500 dark:bg-gray-700 dark:border-l-gray-700  dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:border-blue-500"
                    placeholder="Поиск" required>

                  <button type="submit"
                    class="absolute top-0 right-0 p-2.5 text-sm font-medium text-white bg-blue-700 rounded-r-lg border border-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">
                    <svg aria-hidden="true" class="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24"
                      xmlns="http://www.w3.org/2000/svg">
                      <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                        d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z"></path>
                    </svg>
                    <span class="sr-only">Search</span>
                  </button>
                </div>
              </div>
              <div class="flex">
                <div class="mr-2">
                  <input @click="SearchText.isFIO = true" id="disabled-radio-1" type="radio" value=""
                    name="disabled-radio"
                    class="w-4 h-4 text-blue-600 bg-gray-100 border-gray-300 focus:ring-blue-500 dark:focus:ring-blue-600 dark:ring-offset-gray-800 focus:ring-2 dark:bg-gray-700 dark:border-gray-600">
                  <label for="disabled-radio-1" class="ml-2 text-sm font-medium text-gray-400 dark:text-gray-500">Поиск
                    по ФИО</label>
                </div>
                <div class="">
                  <input @click="SearchText.isFIO = false" id="disabled-radio-2" type="radio" value=""
                    name="disabled-radio"
                    class="w-4 h-4 text-blue-600 bg-gray-100 border-gray-300 focus:ring-blue-500 dark:focus:ring-blue-600 dark:ring-offset-gray-800 focus:ring-2 dark:bg-gray-700 dark:border-gray-600">
                  <label for="disabled-radio-2" class="ml-2 text-sm font-medium text-gray-400 dark:text-gray-500">Поиск
                    по дате рождения</label>
                </div>
              </div>

            </form>

          </div>


          <table class="w-full text-sm text-left text-gray-500 dark:text-gray-400 mx-4 px-4">
            <thead class="text-xs text-gray-700 uppercase bg-gray-100 dark:bg-gray-700 dark:text-gray-400">



              <tr>

                <th v-for="el in headers" :key="el.id" scope="col" class="text-sm font-medium px-6 py-4">
                  {{ el.text }}
                </th>

              </tr>
            </thead>
            <tbody>
              <tr v-for="el in filteredUser()" :key="el"
                class="bg-white border-b dark:bg-gray-800 dark:border-gray-700 hover:bg-gray-50 dark:hover:bg-gray-600">
                <td class="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900">{{ el.fio }}</td>
                <td class="text-sm text-gray-900 font-light px-6 py-4 whitespace-nowrap">
                  {{ el.birthDay }}
                </td>
                <td class="text-sm text-gray-900 font-light px-6 py-4 whitespace-nowrap">
                  {{ el.country }}
                </td>
                <td class="text-sm text-gray-900 font-light px-6 py-4 whitespace-nowrap">
                  {{ el.city }}
                </td>
                <td class="text-sm text-gray-900 font-light px-6 py-4 whitespace-nowrap">
                  {{ el.isMale }}
                </td>
              </tr>



            </tbody>
          </table>

        </div>
      </div>

      <nav aria-label="Page  navigation example">
        <ul class="inline-flex items-center pt-5 -space-x-px">
          <li v-for="(el, index) in countPage()" :key="index">
            <a @click="page = el" :class="{ 'text-blue-700': page == el }"
              class="hover:cursor-pointer px-3 py-2 leading-tight  bg-white border border-gray-300">{{
                index
              }}</a>
          </li>
        </ul>
      </nav>

    </div>
    <create-user @UpdateData="UpdateList"></create-user>

  </div>
</template>

<script>

import CreateUser from './components/CreateUser.vue';
export default {
  name: 'App',
  components: {
    CreateUser
  },
  data() {
    return {
      headers: [
        {
          text: 'ФИО',
          align: 'start',
          sortable: false,
          value: 'name',
        },
        { text: 'Дата рождения', value: 'BirthDay' },
        { text: 'Страна', value: 'Country' },
        { text: 'Город', value: 'City' },
        { text: 'Пол', value: 'Gender' },
      ],
      UserList: [],
      size: 7,
      page: 0,
      openRadioList: false,

      SearchText: {
        "text": "",
        "isFIO": true
      },

      Filters: [
        { index: 0, Name: "По Алфавиту" },
        { index: 1, Name: "По дате рождения" },
        { index: 2, Name: "По стране проживания" },
        { index: 3, Name: "По городу рождения" },
      ],
      SelectFilter: { index: 0, Name: "Сортировка" },
    }
  },

  computed: {
    start() {
      return (this.page - 1) * this.size;
    },
    end() {
      return this.page * this.size - 1;
    },

  },
  watch: {

    SearchText: {
      deep: true,
      handler(data) {
        console.log(data)
        if (data.text == "") {
          this.UpdateList()
        }
      }

    }
  },

  async mounted() {

    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");
    var requestOptions = {
      method: 'GET',
      headers: myHeaders,
      redirect: 'follow'
    };
    await fetch("https://localhost:7193/api/User/GetAll", requestOptions)
      .then(response => response.json())
      .then(x => this.UserList = x)
      .catch(error => console.log('error', error));

    console.log(this.UserList)
  },



  methods: {
    async AcceptFilter(el) {
      this.openRadioList = false;

      this.SelectFilter = el;
      console.log("is true")
      var myHeaders = new Headers();
      myHeaders.append("Content-Type", "application/json");
      var requestOptions = {
        method: 'GET',
        headers: myHeaders,
        redirect: 'follow'
      };
      await fetch("https://localhost:7193/api/User/GetSorted?sortState=" + el.index, requestOptions)
        .then(response => response.json())
        .then(x => this.UserList = x)
        .catch(error => console.log('error', error));

      console.log(this.UserList)
    },


    async Search() {
      var myHeaders = new Headers();
      myHeaders.append("Content-Type", "application/json");

      if (this.SearchText.isFIO) {
        var raw = JSON.stringify({
          "fio": this.SearchText.text,
          "isFIO": this.SearchText.isFIO
        });
      }
      else {
        raw = JSON.stringify({
          "birthDay": this.SearchText.text,
          "isFIO": this.SearchText.isFIO
        });
      }

      var requestOptions = {
        method: 'POST',
        headers: myHeaders,
        body: raw,
        redirect: 'follow'
      };
      await fetch("https://localhost:7193/api/User/GetFindUser", requestOptions)
        .then(response => response.json())
        .then(x => this.UserList = x)
        .catch(error => console.log('error', error));
      this.page = 0;

      console.log(this.UserList)
    },
    filteredUser() {
      console.log(this.UserList)
      const filteredUser = this.UserList.slice(this.start, this.end);

      return filteredUser;
    },
    countPage() {
      if (this.UserList.length && this.size > 0) {
        console.log(this.size)
        let res = parseInt(this.UserList.length / (this.size - 1))
        return res;
      }
      else {
        return 0;
      }
    },

    async UpdateList() {
      console.log("is true")
      var myHeaders = new Headers();
      myHeaders.append("Content-Type", "application/json");
      var requestOptions = {
        method: 'GET',
        headers: myHeaders,
        redirect: 'follow'
      };
      await fetch("https://localhost:7193/api/User/GetAll", requestOptions)
        .then(response => response.json())
        .then(x => this.UserList = x)
        .catch(error => console.log('error', error));

      console.log(this.UserList)
    }
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
</style>
