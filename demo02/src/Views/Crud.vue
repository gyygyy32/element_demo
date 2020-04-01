<template>
  <div id="app">
    <el-row>
      <el-col :span="24" id="wocontent">
        <div class="box box-primary">
          <div class="box-body">
            <div class="tool-btn">
              <el-button icon="el-icon-search" type="primary" @click="queryFun()">查询</el-button>
              <el-button class="btn-add"
               
                type="primary"
                icon="el-icon-circle-plus"
                @click="() => $router.push({ path: '/Add' })"
              >添加</el-button>
            </div>

            <el-table :data="tableData" stripe style="width: 100%">
              <el-table-column prop="field1" label="字段1"></el-table-column>
              <el-table-column prop="field2" label="字段2"></el-table-column>
              <el-table-column prop="field3" label="字段3"></el-table-column>
              <el-table-column fixed="right" label="操作" width="250">
                <template slot-scope="scope">
                  <el-button size="mini" @click="editClick(scope.$index, scope.row)">编辑</el-button>
                  <el-button
                    size="mini"
                    type="danger"
                    @click="deleteClick(scope.$index, scope.row)"
                  >删除</el-button>
                </template>
              </el-table-column>
            </el-table>
          </div>
        </div>
      </el-col>
    </el-row>
  </div>
</template>

<script>
import request from "../utils/request";
import {initData,delData,queryData,updateData,getEditData} from "../utils/request01";
export default {
  name: "Query",
  data() {
    return {
      tableData: [],
    };
  },
  methods: {
    async queryFun(){
       let res= await queryData()
       this.tableData =res.data
    },
    async deleteClick(inedx, row) {
      let res = await delData(row.field1)
      this.queryFun()

    },
    editClick(index, row) {
      debugger;
      let self = this;
      //改为路由
      this.$router.push({
        name: "Edit",
        params: {
          field1: row.field1
        }
      }); 
    },
    /**
     * 清除form数据
     */
    clearFormData() {
      this.form.field1 = "";
      this.form.field2 = "";
      this.form.field3 = "";

    },
    async initFun(){
      debugger;
      let res = await initData();
      this.tableData = res.data;
    }
   
  },
  mounted: function() {
    //this.query();
    //this.init();
    this.queryFun();
  }
};
</script>

<style scoped>
.btn-add{
  /* margin-right: "10px" */
}
.el-dialog .el-input,
.el-select {
  width: 300px;
}
/* .el-dialog .el-select{
    width:300px;
} */
.tool-btn {
  display: flex;
  flex-flow: row;
  justify-content: flex-start;
}
.box {
  position: relative;
  border-radius: 3px;
  background: #ffffff;

  margin-bottom: 20px;
  width: 100%;
  box-shadow: 0 1px 1px rgba(0, 0, 0, 0.1);
}
.box.box-primary {
  /* border-top-color: #3c8dbc; */
}
.box-body {
  border-top-left-radius: 0;
  border-top-right-radius: 0;
  border-bottom-right-radius: 3px;
  border-bottom-left-radius: 3px;
  padding: 10px;
}

#container {
  margin-top: -100px;
}
</style>