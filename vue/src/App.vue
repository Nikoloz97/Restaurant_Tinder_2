<template>
  <span id="app">
    <div id="main-container">
      <b-row id="sub-container">
        <b-col id="menuColumn" class="col-2 panel">
          <div>
            <menu-column
              class="content"
              id="menu"
              style="
                box-shadow: 5px 5px 5px rgba(0, 0, 0, 0.25);
                background: rgba(255, 255, 255, 0.5);
                border: transparent !important;
              "
            />
          </div>
        </b-col>
        <b-col id="homeColumn" class="col-8 panel">
          <div>
            <router-view class="content" />
          </div>
        </b-col>
        <b-col id="detailsColumn" class="col-2 panel">
          <div>
            <details-column
              class="content"
              id="details"
              style="
                box-shadow: 5px 5px 5px rgba(0, 0, 0, 0.25);
                background: rgba(255, 255, 255, 0.5);
              "
            />
          </div>
        </b-col>
      </b-row>
    </div>
  </span>
</template>
<script>
import PartyService from "./services/PartyService.js";
import MenuColumn from "./components/MenuColumn.vue";
import DetailsColumn from "./components/DetailsColumn.vue";

export default {
  data() {
    return {
      parties: [],
    };
  },
  name: "app",
  components: {
    MenuColumn,
    DetailsColumn,
  },
  methods: {
    getParties() {
      let myVar;
      PartyService.getParties(1)
        .then((response) => {
          // intake a list of parties and set it to the parties variable and add it to the store
          this.parties = response.data;
          myVar = this.parties;
          console.log(myVar);
          this.$store.commit("SET_CURRENT_PARTIES", response.data);
        })
        .catch((error) => {
          console.log(error);
        });
    },
  },
  created() {
    this.getParties();
  },
};
</script>
<style >
body {
  background: url("./imgs/Background_img_flipped.jpg") no-repeat center center
    fixed;
  -webkit-background-size: cover;
  -moz-background-size: cover;
  -o-background-size: cover;
  background-size: cover;
}
#header {
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-content: center;
  background: rgba(255, 255, 255, 0.5);
  margin: 1vw;
  width: 92vw;
  margin-bottom: 0vw;
  box-shadow: 5px 5px 5px rgba(0, 0, 0, 0.5);
}
.btn {
  box-shadow: 5px 5px 5px rgba(0, 0, 0, 0.5);
  margin: 0.3rem;
}
.btn:hover {
  box-shadow: 5px 5px 5px rgba(0, 0, 0, 0.5);
  margin: 0.3rem;
  background: white;
}
#app {
  height: 100%;
  min-height: 100%;
}
.panel {
  height: 80vh;
}

#logo {
  text-align: center;
  height: 320px;
}

.content {
  box-shadow: 5px 5px 5px rgba(0, 0, 0, 0.25);
  background: rgba(255, 255, 255, 0.5);
  min-height: 70vh;
  height: 95vh;
  overflow: auto;
  padding: 10px 10px 10px 10px !important;
  border: transparent !important;
  border-radius: 5px;
}
#main-container {
  padding: 4vw;
  padding-top: 1vw;
  padding-bottom: 0vh;
  justify-content: center;
  align-content: center;
  height: auto;
}
#sub-container {
  height: 85vh;
}
@keyframes gradient {
  0% {
    background-position: 0% 50%;
  }
  50% {
    background-position: 100% 50%;
  }
  100% {
    background-position: 0% 50%;
  }
}
#nav-bar {
  margin: 3vw;
  width: 92vw;
  margin-bottom: 0vw;
}
.solid-text {
  opacity: 100%;
  font-weight: bolder;
  color: black;
}

::-webkit-scrollbar {
  width: 10px;
  border-radius: 5px;
}
::-webkit-scrollbar-track {
  background: rgb(179, 177, 177);
  box-shadow: 5px 5px 5px rgba(0, 0, 0, 0.25);
  border-radius: 5px;
}

::-webkit-scrollbar-thumb {
  background: rgb(136, 136, 136);
  box-shadow: 5px 5px 5px rgba(0, 0, 0, 0.25);
}

::-webkit-scrollbar-thumb:hover {
  background: rgb(100, 100, 100);
  box-shadow: 5px 5px 5px rgba(0, 0, 0, 0.25);
}

::-webkit-scrollbar-thumb:active {
  background: rgb(68, 68, 68);
  box-shadow: 5px 5px 5px rgba(0, 0, 0, 0.25);
}
</style>