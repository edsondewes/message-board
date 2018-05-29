import React from "react";
import octicons from "octicons";

const Octicon = ({ ico }) => (
  <span
    dangerouslySetInnerHTML={{
      __html: octicons[ico].toSVG(),
    }}
  />
);

export default Octicon;
