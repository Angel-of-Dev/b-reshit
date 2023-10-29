---
layout: home
---

<script setup>
  import { ref } from 'vue';

  const cardImgPath = ref('card.png');
</script>

<img :src="cardImgPath" @mouseover="cardImgPath='card.back.png'" @mouseleave="cardImgPath='card.png'" style="max-height:350px;margin-left:33%;" />

