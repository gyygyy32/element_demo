<template>
  <div id="app">
    <el-page-header @back="goBack" content="编辑"></el-page-header>
    <div class="form-content">
      <el-form :model="updateForm"  :rules="rules" ref="updateForm" class="demo-form">
        <el-form-item label="字段1" :label-width="'120px'" prop="field1">
          <el-input v-model="updateForm.field1" autocomplete="off"></el-input>
        </el-form-item>
        <el-form-item label="字段2" :label-width="'120px'" prop="field2">
          <el-input v-model="updateForm.field2" autocomplete="off"></el-input>
        </el-form-item>
        <el-form-item label="字段3" :label-width="'120px'" prop="field3">
          <el-input v-model="updateForm.field3" autocomplete="off"></el-input>
        </el-form-item>
        <el-form-item>
          <el-button @click="updateDialogFormVisible = false">取 消</el-button>
          <el-button id="btn" type="primary" @click="update('updateForm')">确 定</el-button>
        </el-form-item>
      </el-form>
    </div>
  </div>
</template>

<script>
import { updateData, getDetailData } from "../utils/request01";
export default {
  name: "Edit",
  data() {
    return {
      rules: {
        field1: [{ required: true, message: "请填字段1", trigger: "blur" }],
        field2: [{ required: true, message: "请填字段2", trigger: "blur" }],
        field3: [{ required: true, message: "请填字段3", trigger: "blur" }]
      },
      updateForm: {},
    };
  },
  methods: {
    goBack() {
      this.$router.push({ path: "/" });
    },
    async getEdit(id) {
      let res = await getDetailData(id);
      this.updateForm = {...this.updateForm,...res.data}

    },
    async update(formName) {
      if(! await this.$refs[formName].validate()) {return;}
      let res = await updateData({...this.updateForm });
      this.$message.success("修改成功");
      this.$router.push({ path: "/" });
    }
  },
  mounted: function() {
    this.getEdit(this.$route.params.field1);
  }
};
</script>

<style scoped>
.demo-form {
  width: 460px;
}
.form-content {
  display: flex;
  justify-content: center; /* 水平居中 */
  align-items: center; /* 垂直居中 */
}
.el-row {
  margin-bottom: 20px;
  &:last-child {
    margin-bottom: 0;
  }
}
</style>