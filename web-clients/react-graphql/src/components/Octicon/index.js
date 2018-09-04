import React from "react";
import octicons from "octicons";
import style from "./_style.css";

const Octicon = ({ ico }) => (
  <span
    className={style.octicon}
    dangerouslySetInnerHTML={{
      __html: octicons[ico].toSVG(),
    }}
  />
);

export default Octicon;
